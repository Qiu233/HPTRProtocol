using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PacketTests")]

namespace HPTRProtocol;
public class PacketSerializer
{
	internal readonly Dictionary<MessageID, Type> Packets = new();
	public bool IsClient
	{
		get;
	}
	private PacketSerializer(bool client)
	{
		IsClient = client;
	}

	private void Register(Type t)
	{
		if (Activator.CreateInstance(t) is Packet p)
			Packets[p.Type] = t;
	}

	public void Load(Assembly asm)
	{
		asm.DefinedTypes.Where(t => t.IsSubclassOf(typeof(Packet)) && !t.IsAbstract).ToList().ForEach(t => Register(t));
	}

#pragma warning disable CA1822 // Mark members as static
	public byte[] Serialize(Packet p)
#pragma warning restore CA1822 // Mark members as static
	{
		using var ms = new MemoryStream();
		using var bw = new BinaryWriter(ms);
		bw.Write((short)0);//placeholder of length
		bw.WriteEnum(p.Type);
		p.Serialize(bw);
		var l = bw.BaseStream.Position;
		bw.BaseStream.Position = 0;
		bw.Write((short)l);
		var bs = ms.ToArray();
		return bs;
	}

	public Packet Deserialize(BinaryReader br0)
	{
		var l = br0.ReadInt16();
		using var ms = new MemoryStream(br0.ReadBytes(l - 2));
		using var br = new BinaryReader(ms);
		Packet result = null;
		var msgid = (MessageID)br.ReadByte();
		/*if (msgid == MessageID.NetModules)
		{
			var moduletype = (NetModuleType)br.ReadInt16();
			if (moduledeserializers.TryGetValue(moduletype, out var f))
				result = f(br);
			else
				Console.WriteLine($"[Warning] net module type = {moduletype} not defined, ignoring");
		}
		else */
		if (Packets.TryGetValue(msgid, out var f2))
		{
			result = Activator.CreateInstance(f2) as Packet;
			result.Deserialize(br);
		}
		else
			Console.WriteLine($"[Warning] message type = {msgid} not defined, ignoring");

		if (br.BaseStream.Position != br.BaseStream.Length)
			Console.WriteLine($"[Warning] {br.BaseStream.Length - br.BaseStream.Position} not used when deserializing {(IsClient ? "S2C::" : "C2S::")}{result}");
		return result;
	}

	public static PacketSerializer CreateFromAssembly(Assembly asm, bool client)
	{
		PacketSerializer s = new(client);
		s.Load(asm);
		return s;
	}

	public static PacketSerializer CreateFromDefault(bool client)
	{
		return CreateFromAssembly(typeof(PacketSerializer).Assembly, client);// in case of this method being inlined
	}
}

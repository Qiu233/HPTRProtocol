using DotNext;

namespace HPTRProtocol.Packets.NetModules;

public class NetBestiaryModule : NetModulesPacket// TODO: complete this type
{
	public override NetModuleType ModuleType => NetModuleType.NetBestiaryModule;
	public byte[] Data { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		/*BestiaryUnlockType = br.ReadByte();
		NPCNetID = br.ReadInt16();
		if (br.BaseStream.Length != br.BaseStream.Position)
			KillCount = br.ReadUInt16();*/
		Data = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		/*bw.Write(BestiaryUnlockType);
		bw.Write(NPCNetID);
		if (KillCount.TryGet(out ushort v))
			bw.Write(v);*/
		bw.Write(Data);
	}
}
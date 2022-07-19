using DotNext;

namespace HPTRProtocol.Packets.Sync;

public class SyncNPCName : Packet, INPCSlot
{
	public override MessageID Type => MessageID.SyncNPCName;
	public short NPCSlot { get; set; }
	/// <summary>
	/// Only sent from server
	/// </summary>
	public Optional<string> NPCName { get; set; }
	/// <summary>
	/// Only sent from server
	/// </summary>
	public Optional<int> TownNPC { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		if (br.BaseStream.Length == br.BaseStream.Position)
			return;
		NPCName = br.ReadString();
		TownNPC = br.ReadInt32();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		if (NPCName.TryGet(out string name) && TownNPC.TryGet(out int townNPC))
		{
			bw.Write(name);
			bw.Write(townNPC);
		}
	}
}
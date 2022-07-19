namespace HPTRProtocol.Packets.Sync;

public class AddNPCBuff : Packet, INPCSlot
{
	public override MessageID Type => MessageID.AddNPCBuff;
	public short NPCSlot { get; set; }
	public ushort BuffType { get; set; }
	public short BuffTime { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		BuffType = br.ReadUInt16();
		BuffTime = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		bw.Write(BuffType);
		bw.Write(BuffTime);
	}
}
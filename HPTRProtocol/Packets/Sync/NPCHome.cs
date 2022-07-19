namespace HPTRProtocol.Packets.Sync;

public class NPCHome : Packet, INPCSlot
{
	public override MessageID Type => MessageID.NPCHome;
	public short NPCSlot { get; set; }
	public Position<short> Position { get; set; }
	public byte Homeless { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		Position = br.ReadS<Position<short>>();
		Homeless = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		bw.WriteS(Position);
		bw.Write(Homeless);
	}
}
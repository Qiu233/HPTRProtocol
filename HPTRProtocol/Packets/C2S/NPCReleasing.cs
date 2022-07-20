namespace HPTRProtocol.Packets.C2S;

public class NPCReleasing : Packet
{
    public override MessageID Type => MessageID.NPCReleasing;
    public Position Position { get; set; }
    public short NPCType { get; set; }
    public byte Style { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadSerializable<Position>();
		NPCType = br.ReadInt16();
		Style = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Position);
		bw.Write(NPCType);
		bw.Write(Style);
	}
}
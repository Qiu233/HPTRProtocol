namespace HPTRProtocol.Packets.Sync;

public class PaintWall : Packet
{
	public override MessageID Type => MessageID.PaintWall;
	public ShortPosition Position { get; set; }
	public byte Color { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadSerializable<ShortPosition>();
		Color = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Position);
		bw.Write(Color);
	}
}
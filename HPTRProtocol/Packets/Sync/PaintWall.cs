namespace HPTRProtocol.Packets.Sync;

public class PaintWall : Packet
{
	public override MessageID Type => MessageID.PaintWall;
	public Position<short> Position { get; set; }
	public byte Color { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadS<Position<short>>();
		Color = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteS(Position);
		bw.Write(Color);
	}
}
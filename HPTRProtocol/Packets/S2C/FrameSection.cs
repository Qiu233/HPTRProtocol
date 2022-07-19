namespace HPTRProtocol.Packets.S2C;

public class FrameSection : Packet
{
	public override MessageID Type => MessageID.FrameSection;
	public Position<short> Start { get; set; }
	public Position<short> End { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Start = br.ReadS<Position<short>>();
		End = br.ReadS<Position<short>>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteS(Start);
		bw.WriteS(End);
	}
}

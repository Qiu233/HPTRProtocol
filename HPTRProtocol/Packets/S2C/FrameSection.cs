namespace HPTRProtocol.Packets.S2C;

public class FrameSection : Packet
{
	public override MessageID Type => MessageID.FrameSection;
	public ShortPosition Start { get; set; }
	public ShortPosition End { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Start = br.ReadSerializable<ShortPosition>();
		End = br.ReadSerializable<ShortPosition>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Start);
		bw.WriteSerializable(End);
	}
}

namespace HPTRProtocol.Packets.C2S;

public class RequestSign : Packet
{
	public override MessageID Type => MessageID.RequestSign;
	public Position<short> Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadS<Position<short>>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteS(Position);
}
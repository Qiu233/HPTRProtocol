namespace HPTRProtocol.Packets.C2S;

public class RequestSign : Packet
{
	public override MessageID Type => MessageID.RequestSign;
	public ShortPosition Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadSerializable<ShortPosition>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteSerializable(Position);
}
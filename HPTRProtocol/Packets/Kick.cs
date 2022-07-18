namespace HPTRProtocol.Packets;

public class Kick : Packet
{
	public override MessageID Type => MessageID.Kick;
	public NetworkText Reason { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Reason = NetworkText.Deserialize(br);

	protected override void SerializeOverride(BinaryWriter bw) => Reason.Serialize(bw);
}

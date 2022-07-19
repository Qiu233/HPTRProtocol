namespace HPTRProtocol.Packets.S2C;

public class Disconnect : Packet
{
	public override MessageID Type => MessageID.Disconnect;
	public NetworkText Reason { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Reason = NetworkText.Deserialize(br);

	protected override void SerializeOverride(BinaryWriter bw) => Reason.Serialize(bw);
}

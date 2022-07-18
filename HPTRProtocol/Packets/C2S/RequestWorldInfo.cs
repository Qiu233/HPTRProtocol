namespace HPTRProtocol.Packets.C2S;

public class RequestWorldInfo : Packet
{
	public override MessageID Type => MessageID.RequestWorldInfo;

	protected override void DeserializeOverride(BinaryReader br)
	{
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
	}
}

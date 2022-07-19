namespace HPTRProtocol.Packets.C2S;

public class RequestWorldData : Packet
{
	public override MessageID Type => MessageID.RequestWorldData;

	protected override void DeserializeOverride(BinaryReader br)
	{
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
	}
}

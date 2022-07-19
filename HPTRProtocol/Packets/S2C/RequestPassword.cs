namespace HPTRProtocol.Packets.S2C;

public class RequestPassword : Packet
{
    public override MessageID Type => MessageID.RequestPassword;

	protected override void DeserializeOverride(BinaryReader br)
	{
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
	}
}

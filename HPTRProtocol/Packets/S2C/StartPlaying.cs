namespace HPTRProtocol.Packets.S2C;

public class StartPlaying : Packet
{
    public override MessageID Type => MessageID.StartPlaying;

	protected override void DeserializeOverride(BinaryReader br)
	{
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
	}
}

namespace HPTRProtocol.Packets.C2S;

public class AnglerQuestFinished : Packet
{
    public override MessageID Type => MessageID.AnglerQuestFinished;

	protected override void DeserializeOverride(BinaryReader br)
	{
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
	}
}
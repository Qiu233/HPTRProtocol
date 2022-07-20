namespace HPTRProtocol.Packets.S2C;

public class AnglerQuest : Packet
{
    public override MessageID Type => MessageID.AnglerQuest;
    public byte QuestType { get; set; }
    public bool Finished { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		QuestType = br.ReadByte();
		Finished = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(QuestType);
		bw.Write(Finished);
	}
}
namespace HPTRProtocol.Packets.C2S;

public class AnglerQuestCountSync : Packet, IPlayerSlot
{
    public override MessageID Type => MessageID.AnglerQuestCountSync;
    public byte PlayerSlot { get; set; }
    public int AnglerQuestsFinished { get; set; }
    public int GolferScoreAccumulated { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		AnglerQuestsFinished = br.ReadInt32();
		GolferScoreAccumulated = br.ReadInt32();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(AnglerQuestsFinished);
		bw.Write(GolferScoreAccumulated);
	}
}
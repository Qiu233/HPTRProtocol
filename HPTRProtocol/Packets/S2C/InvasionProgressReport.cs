namespace HPTRProtocol.Packets.S2C;

public class InvasionProgressReport : Packet
{
	public override MessageID Type => MessageID.InvasionProgressReport;
	public int Progress { get; set; }
	public int ProgressMax { get; set; }
	public sbyte Icon { get; set; }
	public sbyte Wave { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Progress = br.ReadInt32();
		ProgressMax = br.ReadInt32();
		Icon = br.ReadSByte();
		Wave = br.ReadSByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Progress);
		bw.Write(ProgressMax);
		bw.Write(Icon);
		bw.Write(Wave);
	}
}
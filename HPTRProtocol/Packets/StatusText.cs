namespace HPTRProtocol.Packets;

public class StatusText : Packet
{
	public override MessageID Type => MessageID.StatusText;
	public int Max { get; set; }
	public NetworkText Text { get; set; }
	public byte Flag { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Max = br.ReadInt32();
		Text = NetworkText.Deserialize(br);
		Flag = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Max);
		Text.Serialize(bw);
		bw.Write(Flag);
	}
}

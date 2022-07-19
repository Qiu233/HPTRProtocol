namespace HPTRProtocol.Packets.S2C;

public class StatusText : Packet
{
	public override MessageID Type => MessageID.StatusText;
	public int Max { get; set; }
	public NetworkText Text { get; set; }
	public byte Flags { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Max = br.ReadInt32();
		Text = NetworkText.Deserialize(br);
		Flags = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Max);
		Text.Serialize(bw);
		bw.Write(Flags);
	}
}

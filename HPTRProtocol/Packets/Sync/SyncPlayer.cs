namespace HPTRProtocol.Packets.Sync;

public class SyncPlayer : Packet
{
	public override MessageID Type => MessageID.SyncPlayer;
	public byte PlayerSlot { get; set; }
	public byte SkinVariant { get; set; }
	public byte Hair { get; set; }
	public string Name { get; set; }
	public byte HairDye { get; set; }
	public BitsByte Bit1 { get; set; }
	public BitsByte Bit2 { get; set; }
	public byte HideMisc { get; set; }
	public Color HairColor { get; set; }
	public Color SkinColor { get; set; }
	public Color EyeColor { get; set; }
	public Color ShirtColor { get; set; }
	public Color UnderShirtColor { get; set; }
	public Color PantsColor { get; set; }
	public Color ShoeColor { get; set; }
	public BitsByte Bit3 { get; set; }
	public BitsByte Bit4 { get; set; }

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(SkinVariant);
		bw.Write(Hair);
		bw.Write(Name);
		bw.Write(HairDye);
		bw.Write(Bit1);
		bw.Write(Bit2);

		bw.Write(HideMisc);

		bw.Write(HairColor);
		bw.Write(SkinColor);
		bw.Write(EyeColor);
		bw.Write(ShirtColor);
		bw.Write(UnderShirtColor);
		bw.Write(PantsColor);
		bw.Write(ShoeColor);

		bw.Write(Bit3);
		bw.Write(Bit4);
	}
	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		SkinVariant = br.ReadByte();
		Hair = br.ReadByte();
		Name = br.ReadString();
		HairDye = br.ReadByte();
		Bit1 = br.ReadByte();
		Bit2 = br.ReadByte();

		HideMisc = br.ReadByte();

		HairColor = br.ReadColor();
		SkinColor = br.ReadColor();
		EyeColor = br.ReadColor();
		ShirtColor = br.ReadColor();
		UnderShirtColor = br.ReadColor();
		PantsColor = br.ReadColor();
		ShoeColor = br.ReadColor();

		Bit3 = br.ReadByte();
		Bit4 = br.ReadByte();
	}
}
namespace HPTRProtocol.Packets.Sync;

public class Teleport : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.Teleport;
	public BitsByte Bit1 { get; set; }
	public byte PlayerSlot { get; set; }
	public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
	public Vector2 Position { get; set; }
	public byte Style { get; set; }
	public int ExtraInfo { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Bit1 = br.ReadByte();
		PlayerSlot = br.ReadByte();
		HighBitOfPlayerIsAlwaysZero = br.ReadByte();
		Position = br.ReadSerializable<Vector2>();
		Style = br.ReadByte();
		if (Bit1[3])
			ExtraInfo = br.ReadInt32();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Bit1);
		bw.Write(PlayerSlot);
		bw.Write(HighBitOfPlayerIsAlwaysZero);
		bw.WriteSerializable(Position);
		bw.Write(Style);
		if (Bit1[3])
			bw.Write(ExtraInfo);
	}
}
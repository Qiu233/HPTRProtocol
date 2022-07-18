namespace HPTRProtocol.Packets.Sync;

public class SyncProjectile : Packet, IProjSlot, IPlayerSlot
{
	public override MessageID Type => MessageID.SyncProjectile;
	public short ProjSlot { get; set; }
	public Vector2 Position { get; set; }
	public Vector2 Velocity { get; set; }
	public byte PlayerSlot { get; set; }
	public short ProjType { get; set; }
	public BitsByte Bit1 { get; set; }
	public float AI1 { get; set; }
	public float AI2 { get; set; }
	public ushort BannerId { get; set; }
	public short Damange { get; set; }
	public float Knockback { get; set; }
	public short OriginalDamage { get; set; }
	public short UUID { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ProjSlot = br.ReadByte();
		Position = br.ReadS<Vector2>();
		Velocity = br.ReadS<Vector2>();
		PlayerSlot = br.ReadByte();
		ProjType = br.ReadInt16();

		Bit1 = br.ReadByte();
		if (Bit1[0])
			AI1 = br.ReadSingle();
		if (Bit1[1])
			AI2 = br.ReadSingle();
		if (Bit1[3])
			BannerId = br.ReadUInt16();
		if (Bit1[4])
			Damange = br.ReadInt16();
		if (Bit1[5])
			Knockback = br.ReadSingle();
		if (Bit1[6])
			OriginalDamage = br.ReadInt16();
		if (Bit1[7])
			UUID = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ProjSlot);
		bw.WriteS(Position);
		bw.WriteS(Velocity);
		bw.Write(PlayerSlot);
		bw.Write(ProjType);

		bw.Write(Bit1);
		if (Bit1[0])
			bw.Write(AI1);
		if (Bit1[1])
			bw.Write(AI2);
		if (Bit1[3])
			bw.Write(BannerId);
		if (Bit1[4])
			bw.Write(Damange);
		if (Bit1[5])
			bw.Write(Knockback);
		if (Bit1[6])
			bw.Write(OriginalDamage);
		if (Bit1[7])
			bw.Write(UUID);
	}
}
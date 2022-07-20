using DotNext;

namespace HPTRProtocol.Packets.Sync;

public class SyncNPC : Packet
{
	public override MessageID Type => MessageID.SyncNPC;
	public short NPCSlot { get; set; }
	public Vector2 Offset { get; set; }
	public Vector2 Velocity { get; set; }
	public ushort Target { get; set; }
	public BitsByte Bit1 { get; set; }
	public BitsByte Bit2 { get; set; }
	public float AI1 { get; set; }
	public float AI2 { get; set; }
	public float AI3 { get; set; }
	public float AI4 { get; set; }
	public short NPCType { get; set; }
	public byte PlayerCount { get; set; }
	public float StrengthMultiplier { get; set; }
	public BitsByte Bit3 { get; set; }
	public int HP { get; set; }
	public Optional<byte> ReleaseOwner { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		Offset = br.ReadSerializable<Vector2>();
		Velocity = br.ReadSerializable<Vector2>();
		Target = br.ReadUInt16();
		Bit1 = br.ReadByte();
		Bit2 = br.ReadByte();
		if (Bit1[2])
			AI1 = br.ReadSingle();
		if (Bit1[3])
			AI2 = br.ReadSingle();
		if (Bit1[4])
			AI3 = br.ReadSingle();
		if (Bit1[5])
			AI4 = br.ReadSingle();
		NPCType = br.ReadInt16();
		if (Bit2[0])
			PlayerCount = br.ReadByte();
		if (Bit2[2])
			StrengthMultiplier = br.ReadSingle();
		if (!Bit1[7])
		{
			Bit3 = br.ReadByte();
			HP = (byte)Bit3 switch
			{
				2 => br.ReadInt16(),
				4 => br.ReadInt32(),
				_ => br.ReadSByte(),
			};
		}
		if (br.BaseStream.Position != br.BaseStream.Length)
			ReleaseOwner = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		bw.WriteSerializable(Offset);
		bw.WriteSerializable(Velocity);
		bw.Write(Target);
		bw.Write(Bit1);
		bw.Write(Bit2);
		if (Bit1[2])
			bw.Write(AI1);
		if (Bit1[3])
			bw.Write(AI2);
		if (Bit1[4])
			bw.Write(AI3);
		if (Bit1[5])
			bw.Write(AI4);
		bw.Write(NPCType);
		if (Bit2[0])
			bw.Write(PlayerCount);
		if (Bit2[2])
			bw.Write(StrengthMultiplier);
		if (!Bit1[7])
		{
			bw.Write(Bit3);
			switch (Bit3)
			{
				case 2:
					bw.Write((short)HP);
					break;
				case 4:
					bw.Write(HP);
					break;
				default:
					bw.Write((sbyte)HP);
					break;
			}
		}
		if (ReleaseOwner.TryGet(out byte b))
			bw.Write(b);
	}
}
namespace HPTRProtocol.Packets.S2C;

public class SendNPCBuffs : Packet, INPCSlot
{
	public override MessageID Type => MessageID.SendNPCBuffs;
	public short NPCSlot { get; set; }
	public Buff<short>[] Buffs { get; }
	public const int BuffsLength = 5;

	public SendNPCBuffs()
	{
		Buffs = new Buff<short>[BuffsLength];
	}

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		for (int i = 0; i < Buffs.Length; i++)
			Buffs[i] = br.ReadSerializable<Buff<short>>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		for (int i = 0; i < Buffs.Length; i++)
			bw.WriteSerializable(Buffs[i]);
	}
}
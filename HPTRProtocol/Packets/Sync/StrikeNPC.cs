namespace HPTRProtocol.Packets.Sync;

public class StrikeNPC : Packet, INPCSlot
{
	public override MessageID Type => MessageID.StrikeNPC;
	public short NPCSlot { get; set; }
	public short Damage { get; set; }
	public float Knockback { get; set; }
	public byte HitDirection { get; set; }
	public bool Crit { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		Damage = br.ReadInt16();
		Knockback = br.ReadSingle();
		HitDirection = br.ReadByte();
		Crit = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		bw.Write(Damage);
		bw.Write(Knockback);
		bw.Write(HitDirection);
		bw.Write(Crit);
	}
}
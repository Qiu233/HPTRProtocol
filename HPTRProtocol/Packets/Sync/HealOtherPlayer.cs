namespace HPTRProtocol.Packets.Sync;

public class HealOtherPlayer : Packet, IOtherPlayerSlot
{
	public override MessageID Type => MessageID.SpiritHeal;
	public byte OtherPlayerSlot { get; set; }
	public short Amount { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		OtherPlayerSlot = br.ReadByte();
		Amount = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(OtherPlayerSlot);
		bw.Write(Amount);
	}
}
namespace HPTRProtocol.Packets.Sync;

public class HealEffect : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.HealEffect;
	public byte PlayerSlot { get; set; }
	public short Amount { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Amount = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Amount);
	}
}
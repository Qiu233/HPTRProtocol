namespace HPTRProtocol.Packets.Sync;

public class ManaEffect : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.ManaEffect;
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
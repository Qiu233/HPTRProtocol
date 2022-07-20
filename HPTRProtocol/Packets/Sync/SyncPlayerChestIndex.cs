namespace HPTRProtocol.Packets.Sync;

public class SyncPlayerChestIndex : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.SyncPlayerChestIndex;
	public byte PlayerSlot { get; set; }
	public short ChestIndex { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		ChestIndex = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(ChestIndex);
	}
}
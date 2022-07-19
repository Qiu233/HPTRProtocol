namespace HPTRProtocol.Packets.Sync;

public class SyncPlayerInvSlot : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.SyncPlayerInvSlot;
	public byte PlayerSlot { get; set; }
	public short ItemSlot { get; set; }
	public short Stack { get; set; }
	public byte Prefix { get; set; }
	public short ItemType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		ItemSlot = br.ReadInt16();
		Stack = br.ReadInt16();
		Prefix = br.ReadByte();
		ItemType = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(ItemSlot);
		bw.Write(Stack);
		bw.Write(Prefix);
		bw.Write(ItemType);
	}
}

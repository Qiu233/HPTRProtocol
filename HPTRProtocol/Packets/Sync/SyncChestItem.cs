﻿namespace HPTRProtocol.Packets.Sync;

public class SyncChestItem : Packet
{
	public override MessageID Type => MessageID.SyncChestItem;
	public short ChestSlot { get; set; }
	public byte ChestItemSlot { get; set; }
	public short Stack { get; set; }
	public byte Prefix { get; set; }
	public short ItemType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChestSlot = br.ReadInt16();
		ChestItemSlot = br.ReadByte();
		Stack = br.ReadInt16();
		Prefix = br.ReadByte();
		ItemType = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChestSlot);
		bw.Write(ChestItemSlot);
		bw.Write(Stack);
		bw.Write(Prefix);
		bw.Write(ItemType);
	}
}
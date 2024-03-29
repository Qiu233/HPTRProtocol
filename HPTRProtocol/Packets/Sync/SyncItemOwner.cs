﻿namespace HPTRProtocol.Packets.Sync;

public class SyncItemOwner : Packet, IItemSlot, IOtherPlayerSlot
{
    public override MessageID Type => MessageID.SyncItemOwner;
    public short ItemSlot { get; set; }
    public byte OtherPlayerSlot { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ItemSlot = br.ReadInt16();
		OtherPlayerSlot = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ItemSlot);
		bw.Write(OtherPlayerSlot);
	}
}

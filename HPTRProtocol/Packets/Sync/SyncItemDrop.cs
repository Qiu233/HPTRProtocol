﻿namespace HPTRProtocol.Packets.Sync;

public class SyncItemDrop : Packet, IItemSlot
{
	public override MessageID Type => MessageID.SyncItemDrop;
	public short ItemSlot { get; set; }
	public Vector2 Position { get; set; }
	public Vector2 Velocity { get; set; }
	public short Stack { get; set; }
	public byte Prefix { get; set; }
	public byte Owner { get; set; }
	public short ItemType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ItemSlot = br.ReadInt16();
		Position = br.ReadSerializable<Vector2>();
		Velocity = br.ReadSerializable<Vector2>();
		Stack = br.ReadInt16();
		Prefix = br.ReadByte();
		Owner = br.ReadByte();
		ItemType = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ItemSlot);
		bw.WriteSerializable(Position);
		bw.WriteSerializable(Velocity);
		bw.Write(Stack);
		bw.Write(Prefix);
		bw.Write(Owner);
		bw.Write(ItemType);
	}
}

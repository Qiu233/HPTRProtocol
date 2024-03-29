﻿namespace HPTRProtocol.Packets.Sync;

public class TileChange : Packet
{
	public override MessageID Type => MessageID.TileChange;
	public byte ChangeType { get; set; }
	public ShortPosition Position { get; set; }
	public short TileType { get; set; }
	public byte Style { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChangeType = br.ReadByte();
		Position = br.ReadSerializable<ShortPosition>();
		TileType = br.ReadInt16();
		Style = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChangeType);
		bw.WriteSerializable(Position);
		bw.Write(TileType);
		bw.Write(Style);
	}
}

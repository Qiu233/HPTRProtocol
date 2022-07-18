﻿namespace HPTRProtocol.Packets.Sync;

public class TileSquare : Packet
{
	public override MessageID Type => MessageID.TileSquare;
	public SquareData Data { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Data = br.ReadS<SquareData>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteS(Data);
}

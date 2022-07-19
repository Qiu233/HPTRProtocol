namespace HPTRProtocol.Packets.Sync;

public class LiquidUpdate : Packet
{
	public override MessageID Type => MessageID.LiquidUpdate;
	public Position<short> TilePosition { get; set; }
	public byte Liquid { get; set; }
	public byte LiquidType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		TilePosition = br.ReadS<Position<short>>();
		Liquid = br.ReadByte();
		LiquidType = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteS(TilePosition);
		bw.Write(Liquid);
		bw.Write(LiquidType);
	}
}

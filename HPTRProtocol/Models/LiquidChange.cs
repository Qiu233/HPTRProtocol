namespace HPTRProtocol.Models;

public struct LiquidChange
{
	public Position<short> Position { get; set; }
	public byte LiquidAmount { get; set; }
	public LiquidType LiquidType { get; set; }
}

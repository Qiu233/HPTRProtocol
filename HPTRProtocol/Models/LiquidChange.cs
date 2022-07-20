using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

public struct LiquidChange : ISerializable
{
	public ShortPosition Position { get; set; }
	public byte LiquidAmount { get; set; }
	public LiquidType LiquidType { get; set; }

	public void Deserialize(BinaryReader br)
	{
		short y = br.ReadInt16();
		short x = br.ReadInt16();
		Position = new(x, y);
		LiquidAmount = br.ReadByte();
		LiquidType = br.ReadEnum<LiquidType>();
	}

	public void Serialize(BinaryWriter bw)
	{
		bw.Write(Position.Y);
		bw.Write(Position.X);
		bw.Write(LiquidAmount);
		bw.WriteEnum(LiquidType);
	}
}

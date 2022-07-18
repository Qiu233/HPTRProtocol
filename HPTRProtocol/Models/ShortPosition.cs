using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public partial struct ShortPosition : ISerializable
{
	public ShortPosition(short x, short y)
	{
		X = x;
		Y = y;
	}
	public short X;
	public short Y;
	public override string ToString()
	{
		return $"[{X}, {Y}]";
	}

	public void Serialize(BinaryWriter bw)
	{
		bw.Write(X);
		bw.Write(Y);
	}

	public void Deserialize(BinaryReader br)
	{
		X = br.ReadInt16();
		Y = br.ReadInt16();
	}
}

using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public struct Position : ISerializable
{
	public Position(int x, int y)
	{
		X = x;
		Y = y;
	}
	public int X;
	public int Y;
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
		X = br.ReadInt32();
		Y = br.ReadInt32();
	}
}

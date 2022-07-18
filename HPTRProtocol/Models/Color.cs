using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public struct Color : ISerializable
{
	public int R;
	public int G;
	public int B;
	public Color(byte r, byte g, byte b)
	{
		R = r;
		G = g;
		B = b;
	}

	public static readonly Color White = new(0xFF, 0xFF, 0xFF);

	public void Serialize(BinaryWriter s)
	{
		s.Write((byte)R);
		s.Write((byte)G);
		s.Write((byte)B);
	}

	public void Deserialize(BinaryReader s)
	{
		R = s.ReadByte();
		G = s.ReadByte();
		B = s.ReadByte();
	}
}

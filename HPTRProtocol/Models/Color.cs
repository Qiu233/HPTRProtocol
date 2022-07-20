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

	public void Serialize(BinaryWriter bw)
	{
		bw.Write((byte)R);
		bw.Write((byte)G);
		bw.Write((byte)B);
	}

	public void Deserialize(BinaryReader br)
	{
		R = br.ReadByte();
		G = br.ReadByte();
		B = br.ReadByte();
	}
}

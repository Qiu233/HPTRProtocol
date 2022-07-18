using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public partial struct Vector2 : ISerializable
{
	public Vector2(float x, float y)
	{
		X = x;
		Y = y;
	}

	public float X;
	public float Y;

	public void Serialize(BinaryWriter bw)
	{
		bw.Write(X);
		bw.Write(Y);
	}

	public void Deserialize(BinaryReader br)
	{
		X = br.ReadSingle();
		Y = br.ReadSingle();
	}
}

using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public struct Position<T> : ISerializable where T : unmanaged
{
	public Position(T x, T y)
	{
		X = x;
		Y = y;
	}
	public T X;
	public T Y;
	public override string ToString()
	{
		return $"[{X}, {Y}]";
	}

	public void Serialize(BinaryWriter bw)
	{
		bw.WriteValue(X);
		bw.WriteValue(Y);
	}

	public void Deserialize(BinaryReader br)
	{
		X = br.ReadValue<T>();
		Y = br.ReadValue<T>();
	}
}

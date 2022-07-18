namespace HPTRProtocol.Helpers;

internal static class IOHelper
{
	public unsafe static void WriteValue<T>(this BinaryWriter bw, T w) where T : unmanaged
	{
		Span<byte> data = stackalloc byte[sizeof(T)];
		fixed (byte* ptr = data)
			*(T*)ptr = w;
		bw.Write(data);
	}
	public unsafe static T ReadValue<T>(this BinaryReader br) where T : unmanaged
	{
		Span<byte> data = stackalloc byte[sizeof(T)];
		br.Read(data);
		fixed (byte* ptr = data)
			return *(T*)ptr;
	}
	public static void Write(this BinaryWriter bw, Color color)
	{
		bw.Write((byte)color.R);
		bw.Write((byte)color.G);
		bw.Write((byte)color.B);
	}
	public static Color ReadColor(this BinaryReader br)
	{
		return new()
		{
			R = br.ReadByte(),
			G = br.ReadByte(),
			B = br.ReadByte()
		};
	}
	public static void Write(this BinaryWriter bw, Guid guid) => WriteValue(bw, guid);
	public static Guid ReadGuid(this BinaryReader br) => ReadValue<Guid>(br);
	public static void WriteS<T>(this BinaryWriter bw, T v) where T : ISerializable, new()
	{
		bw.Flush();// TODO: review this
		v.Serialize(bw);
	}
	public static T ReadS<T>(this BinaryReader br) where T : ISerializable, new()
	{
		T t = new();
		t.Deserialize(br);
		return t;
	}
	public unsafe static T ReadEnum<T>(this BinaryReader br) where T : unmanaged, Enum
	{
		return ReadValue<T>(br);
	}
	public unsafe static void WriteEnum<T>(this BinaryWriter bw, T v) where T : unmanaged, Enum
	{
		WriteValue(bw, v);
	}
}
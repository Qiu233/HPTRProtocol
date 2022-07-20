using System.Runtime.CompilerServices;
using System.Text;

namespace HPTRProtocol.Helpers;

/// <summary>
/// A wrapper for BinaryReader
/// </summary>
public sealed class FastBufferReader
{
	private readonly BinaryReader BinaryReader;//no need to dispose
	public FastBufferReader(byte[] data, Encoding encoding, bool copy = false)
	{
		byte[] buffer;
		if (copy)
		{
			buffer = new byte[data.Length];
			data.CopyTo(buffer, 0);
		}
		else
		{
			buffer = data;
		}
		BinaryReader = new BinaryReader(new MemoryStream(buffer), encoding);
	}
	public FastBufferReader(byte[] data, bool copy = false) : this(data, Encoding.UTF8, copy)
	{
	}

	public bool EOS => BinaryReader.BaseStream.Length == BinaryReader.BaseStream.Position;

	public long Position
	{
		get => BinaryReader.BaseStream.Position;
		set => BinaryReader.BaseStream.Position = value;
	}

	public BinaryReader Reader => BinaryReader;

	public unsafe T ReadValue<T>() where T : unmanaged
	{
		Span<byte> data = stackalloc byte[sizeof(T)];
		BinaryReader.Read(data);
		fixed (byte* ptr = data)
			return *(T*)ptr;
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)] public byte ReadByte() => BinaryReader.ReadByte();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public sbyte ReadSByte() => BinaryReader.ReadSByte();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public short ReadInt16() => BinaryReader.ReadInt16();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public ushort ReadUInt16() => BinaryReader.ReadUInt16();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public int ReadInt32() => BinaryReader.ReadInt32();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public uint ReadUInt32() => BinaryReader.ReadUInt32();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public long ReadInt64() => BinaryReader.ReadInt64();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public ulong ReadUInt64() => BinaryReader.ReadUInt64();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public float ReadSingle() => BinaryReader.ReadSingle();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public double ReadDouble() => BinaryReader.ReadDouble();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public string ReadString() => BinaryReader.ReadString();
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public byte[] ReadBytes(int len) => BinaryReader.ReadBytes(len);

	/*
	public T ReadSerializable<T>() where T : ISerializable, new()
	{
		T t = new();
		t.Deserialize(this);
		return t;
	}
	public T ReadEnum<T>() where T : unmanaged, Enum
	{
		return ReadValue<T>();
	}*/
}
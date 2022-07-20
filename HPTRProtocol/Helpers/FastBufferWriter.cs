using DotNext.Buffers;
using DotNext.IO;
using System.Buffers;
using System.Runtime.CompilerServices;
using System.Text;

namespace HPTRProtocol.Helpers;

/// <summary>
/// A little-endian specialized writer compatible with BinaryWriter but much faster.
/// </summary>
public sealed class FastBufferWriter
{
	private readonly ArrayBufferWriter<byte> InternalBuffer;// TODO: find another faster implementation
	private readonly Encoding Encoding;
	public FastBufferWriter() : this(Encoding.UTF8)
	{
	}

	public FastBufferWriter(Encoding encoding)
	{
		InternalBuffer = new ArrayBufferWriter<byte>();
		Encoding = encoding;
	}


	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public unsafe void WriteValue<T>(T v) where T : unmanaged
	{
		Span<byte> data = InternalBuffer.GetSpan(sizeof(T));
		fixed (byte* ptr = data)
			*(T*)ptr = v;
		InternalBuffer.Advance(sizeof(T));
	}

	public void Write(byte v)
	{
		Span<byte> span = InternalBuffer.GetSpan(1);
		span[0] = v;
		InternalBuffer.Advance(1);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Write(sbyte v) => Write((byte)v);

	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(short v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(ushort v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(int v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(uint v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(long v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(ulong v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(float v) => WriteValue(v);
	[MethodImpl(MethodImplOptions.AggressiveInlining)] public void Write(double v) => WriteValue(v);

	public void Write(ReadOnlySpan<byte> buffer)
	{
		int len = buffer.Length;
		Span<byte> data = InternalBuffer.GetSpan(len);
		buffer.CopyTo(data);
		InternalBuffer.Advance(len);
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void Write(byte[] buffer, int index, int count)
	{
		Write(buffer.AsSpan()[index..(index + count)]);
	}

	public void Write(string value)//This wrapper would be a bit slower than BinaryWriter's
	{
		MemoryStream ms = new(256);
		BinaryWriter bw = new(ms, Encoding);
		bw.Write(value);
		Write(ms.ToArray());
	}
	/*
	public void WriteSerializable<T>(T value) where T : ISerializable, new()
	{
		value.Serialize(this);
	}
	public void WriteEnum<T>(T v) where T : unmanaged, Enum
	{
		WriteValue(v);
	}*/

	public byte[] ToArray() => InternalBuffer.WrittenMemory.ToArray();
}
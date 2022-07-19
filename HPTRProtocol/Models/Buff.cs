using System.Runtime.InteropServices;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public struct Buff<TTime> : ISerializable where TTime : unmanaged
{
	public ushort Type { get; set; }
	public TTime Time { get; set; }

	public void Deserialize(BinaryReader br)
	{
		Type = br.ReadUInt16();
		Time = br.ReadValue<TTime>();
	}

	public void Serialize(BinaryWriter bw)
	{
		bw.Write(Type);
		bw.WriteValue(Time);
	}
}
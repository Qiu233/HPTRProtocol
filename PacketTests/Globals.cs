namespace PacketTests;

internal static class Globals
{
	public static readonly PacketSerializer ClientPacketSerializer = PacketSerializer.CreateFromDefault(true);
	public static readonly PacketSerializer ServerPacketSerializer = PacketSerializer.CreateFromDefault(false);

	public static bool BufferEquals(Span<byte> a, Span<byte> b)
	{
		if (a.Length != b.Length)
			return false;
		for (int i = 0; i < a.Length; i++)
			if (a[i] != b[i])
				return false;
		return true;
	}

	public static byte[] ClientSerialize(Packet p) => ClientPacketSerializer.Serialize(p);
	public static Packet ClientDeserialize(byte[] data) => ClientPacketSerializer.Deserialize(new BinaryReader(new MemoryStream(data)));
	public static byte[] ServerSerialize(Packet p) => ServerPacketSerializer.Serialize(p);
	public static Packet ServerDeserialize(byte[] data) => ServerPacketSerializer.Deserialize(new BinaryReader(new MemoryStream(data)));
	
	public static string GetBufferString(byte[] b)
	{
		return string.Join(", ", b.Select(t => $"0x{t:X2}"));
	}
	public static string BuildLogExpectedAndActual(string expected, string actual)
	{
		return $"Expected: {expected}\nActual: {actual}";
	}

	public static void ClientSerializeTest(Packet p, byte[] expected)
	{
		byte[] result = ClientSerialize(p);
		Assert.True(BufferEquals(result, expected), BuildLogExpectedAndActual(GetBufferString(expected), GetBufferString(result)));
	}

	public static void ServerSerializeTest(Packet p, byte[] expected)
	{
		byte[] result = ServerSerialize(p);
		Assert.True(BufferEquals(result, expected), BuildLogExpectedAndActual(GetBufferString(expected), GetBufferString(result)));
	}
}
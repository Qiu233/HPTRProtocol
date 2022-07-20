namespace HPTRProtocol.Models;

public struct ParticleOrchestraSettings : ISerializable
{
	public Vector2 PositionInWorld;

	public Vector2 MovementVector;

	public int PackedShaderIndex;

	public byte IndexOfPlayerWhoInvokedThis;

	public void Serialize(BinaryWriter writer)
	{
		writer.WriteSerializable(PositionInWorld);
		writer.WriteSerializable(MovementVector);
		writer.Write(PackedShaderIndex);
		writer.Write(IndexOfPlayerWhoInvokedThis);
	}
	public void Deserialize(BinaryReader br)
	{
		PositionInWorld = br.ReadSerializable<Vector2>();
		MovementVector = br.ReadSerializable<Vector2>();
		PackedShaderIndex = br.ReadInt32();
		IndexOfPlayerWhoInvokedThis = br.ReadByte();
	}

	public static ParticleOrchestraSettings DeserializeFrom(BinaryReader reader)
	{
		return new ParticleOrchestraSettings
		{
			PositionInWorld = new Vector2(reader.ReadSingle(), reader.ReadSingle()),
			MovementVector = new Vector2(reader.ReadSingle(), reader.ReadSingle()),
			PackedShaderIndex = reader.ReadInt32(),
			IndexOfPlayerWhoInvokedThis = reader.ReadByte()
		};
	}
}


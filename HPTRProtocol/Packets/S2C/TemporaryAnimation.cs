namespace HPTRProtocol.Packets.S2C;

public class TemporaryAnimation : Packet
{
	public override MessageID Type => MessageID.TemporaryAnimation;
	public short AnimationType { get; set; }
	public ushort TileType { get; set; }
	public ShortPosition Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		AnimationType = br.ReadInt16();
		TileType = br.ReadUInt16();
		Position = br.ReadSerializable<ShortPosition>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(AnimationType);
		bw.Write(TileType);
		bw.WriteSerializable(Position);
	}
}
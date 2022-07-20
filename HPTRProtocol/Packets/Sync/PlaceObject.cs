namespace HPTRProtocol.Packets.Sync;

public class PlaceObject : Packet
{
	public override MessageID Type => MessageID.PlaceObject;
	public ShortPosition Position { get; set; }
	public short ObjectType { get; set; }
	public short Style { get; set; }
	public byte Alternate { get; set; }
	public sbyte Random { get; set; }
	public bool Direction { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadSerializable<ShortPosition>();
		ObjectType = br.ReadInt16();
		Style = br.ReadInt16();
		Alternate = br.ReadByte();
		Random = br.ReadSByte();
		Direction = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Position);
		bw.Write(ObjectType);
		bw.Write(Style);
		bw.Write(Alternate);
		bw.Write(Random);
		bw.Write(Direction);
	}
}
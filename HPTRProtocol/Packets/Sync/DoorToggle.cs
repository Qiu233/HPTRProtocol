namespace HPTRProtocol.Packets.Sync;

public class DoorToggle : Packet
{
	public override MessageID Type => MessageID.DoorToggle;
	public bool ChangeType { get; set; }
	public ShortPosition Position { get; set; }
	public byte Direction { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChangeType = br.ReadBoolean();
		Position = br.ReadSerializable<ShortPosition>();
		Direction = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChangeType);
		bw.WriteSerializable(Position);
		bw.Write(Direction);
	}
}

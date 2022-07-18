namespace HPTRProtocol.Packets.Sync;

public class ChangeDoor : Packet
{
	public override MessageID Type => MessageID.ChangeDoor;
	public bool ChangeType { get; set; }
	public ShortPosition Position { get; set; }
	public byte Direction { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChangeType = br.ReadBoolean();
		Position = br.ReadS<ShortPosition>();
		Direction = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChangeType);
		bw.WriteS(Position);
		bw.Write(Direction);
	}
}

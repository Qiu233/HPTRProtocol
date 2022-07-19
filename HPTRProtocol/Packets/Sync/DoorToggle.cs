namespace HPTRProtocol.Packets.Sync;

public class DoorToggle : Packet
{
	public override MessageID Type => MessageID.DoorToggle;
	public bool ChangeType { get; set; }
	public Position<short> Position { get; set; }
	public byte Direction { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChangeType = br.ReadBoolean();
		Position = br.ReadS<Position<short>>();
		Direction = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChangeType);
		bw.WriteS(Position);
		bw.Write(Direction);
	}
}

namespace HPTRProtocol.Packets.Sync;

public class Unlock : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.Unlock;
	public byte PlayerSlot { get; set; }
	public ShortPosition Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Position = br.ReadSerializable<ShortPosition>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.WriteSerializable(Position);
	}
}
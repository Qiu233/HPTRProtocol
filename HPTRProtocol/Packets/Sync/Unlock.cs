namespace HPTRProtocol.Packets.Sync;

public class Unlock : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.Unlock;
	public byte PlayerSlot { get; set; }
	public Position<short> Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Position = br.ReadS<Position<short>>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.WriteS(Position);
	}
}
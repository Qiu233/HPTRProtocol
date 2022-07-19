namespace HPTRProtocol.Packets.Sync;

public class PlayerZone : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayerZone;
	public byte PlayerSlot { get; set; }
	public int Zone { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Zone = br.ReadInt32();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Zone);
	}
}
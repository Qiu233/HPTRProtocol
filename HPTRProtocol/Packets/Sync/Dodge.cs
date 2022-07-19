namespace HPTRProtocol.Packets.Sync;

public class Dodge : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.Dodge;
	public byte PlayerSlot { get; set; }
	public byte DodgeType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		DodgeType = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(DodgeType);
	}
}
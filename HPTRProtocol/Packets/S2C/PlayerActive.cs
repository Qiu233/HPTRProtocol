namespace HPTRProtocol.Packets.S2C;

public class PlayerActive : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayerActive;
	public byte PlayerSlot { get; set; }
	public bool Active { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Active = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Active);
	}
}

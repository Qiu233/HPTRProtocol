namespace HPTRProtocol.Packets.Sync;

public class PlayerPvP : Packet, IPlayerSlot
{
    public override MessageID Type => MessageID.PlayerPvP;
    public byte PlayerSlot { get; set; }
    public bool Pvp { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Pvp = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Pvp);
	}
}
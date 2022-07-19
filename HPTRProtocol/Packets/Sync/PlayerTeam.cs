namespace HPTRProtocol.Packets.Sync;

public class PlayerTeam : Packet, IPlayerSlot
{
    public override MessageID Type => MessageID.PlayerTeam;
    public byte PlayerSlot { get; set; }
    public byte Team { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Team = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Team);
	}
}
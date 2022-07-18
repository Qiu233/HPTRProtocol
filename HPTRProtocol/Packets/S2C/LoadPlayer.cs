namespace HPTRProtocol.Packets.S2C;

public class LoadPlayer : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.LoadPlayer;
	public byte PlayerSlot { get; set; }
	public bool ServerWantsToRunCheckBytesInClientLoopThread { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		ServerWantsToRunCheckBytesInClientLoopThread = br.ReadBoolean();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(ServerWantsToRunCheckBytesInClientLoopThread);
	}
}

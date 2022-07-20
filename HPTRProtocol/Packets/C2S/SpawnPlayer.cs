namespace HPTRProtocol.Packets.C2S;

public class SpawnPlayer : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.SpawnPlayer;
	public byte PlayerSlot { get; set; }
	public ShortPosition Position { get; set; }
	public int Timer { get; set; }
	public PlayerSpawnContext Context { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Position = br.ReadSerializable<ShortPosition>();
		Timer = br.ReadInt32();
		Context = br.ReadEnum<PlayerSpawnContext>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.WriteSerializable(Position);
		bw.Write(Timer);
		bw.WriteEnum(Context);
	}
}

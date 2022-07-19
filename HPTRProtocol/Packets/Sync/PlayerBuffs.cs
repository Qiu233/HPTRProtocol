namespace HPTRProtocol.Packets.Sync;

public class PlayerBuffs : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayerBuffs;
	public byte PlayerSlot { get; set; }
	public ushort[] BuffTypes { get; }
	public const int BuffTypesLength = 22;

	public PlayerBuffs()
	{
		BuffTypes = new ushort[BuffTypesLength];
	}

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		for (int i = 0; i < BuffTypes.Length; i++)
			BuffTypes[i] = br.ReadUInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		for (int i = 0; i < BuffTypes.Length; i++)
			bw.Write(BuffTypes[i]);
	}
}
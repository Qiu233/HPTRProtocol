namespace HPTRProtocol.Packets.Sync;

public class PlayerHealth : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayerHealth;
	public byte PlayerSlot { get; set; }
	public short StatLife { get; set; }
	public short StatLifeMax { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		StatLife = br.ReadInt16();
		StatLifeMax = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(StatLife);
		bw.Write(StatLifeMax);
	}
}

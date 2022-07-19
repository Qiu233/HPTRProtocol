namespace HPTRProtocol.Packets.Sync;

public class PlayerMana : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayerMana;
	public byte PlayerSlot { get; set; }
	public short StatMana { get; set; }
	public short StatManaMax { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		StatMana = br.ReadInt16();
		StatManaMax = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(StatMana);
		bw.Write(StatManaMax);
	}
}
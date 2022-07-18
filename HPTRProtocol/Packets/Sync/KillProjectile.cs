namespace HPTRProtocol.Packets.Sync;

public class KillProjectile : Packet, IProjSlot, IPlayerSlot
{
	public override MessageID Type => MessageID.KillProjectile;
	public short ProjSlot { get; set; }
	public byte PlayerSlot { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ProjSlot = br.ReadInt16();
		PlayerSlot = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ProjSlot);
		bw.Write(PlayerSlot);
	}
}
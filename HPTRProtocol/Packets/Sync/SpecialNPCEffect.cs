namespace HPTRProtocol.Packets.Sync;

public class SpecialNPCEffect : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.SpecialNPCEffect;
	public byte PlayerSlot { get; set; }
	public byte Action { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Action = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Action);
	}
}
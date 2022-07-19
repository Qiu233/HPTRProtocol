namespace HPTRProtocol.Packets.Sync;

[Obsolete("Said to be deprecated.")]
public class StrikeNPCWithHeldItem : Packet, INPCSlot, IPlayerSlot
{
	public override MessageID Type => MessageID.UnusedStrikeNPC;

	public short NPCSlot { get; set; }
	public byte PlayerSlot { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		NPCSlot = br.ReadInt16();
		PlayerSlot = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(NPCSlot);
		bw.Write(PlayerSlot);
	}
}
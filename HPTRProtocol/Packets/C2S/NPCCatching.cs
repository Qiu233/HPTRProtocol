namespace HPTRProtocol.Packets.C2S;

public class NPCCatching : Packet, IPlayerSlot, INPCSlot
{
	public override MessageID Type => MessageID.NPCCatching;
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
namespace HPTRProtocol.Packets.Sync;

public class ActiveNPC : Packet, IPlayerSlot, INPCSlot
{
    public override MessageID Type => MessageID.ActiveNPC;
    public byte PlayerSlot { get; set; }
    public short NPCSlot { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		NPCSlot = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(NPCSlot);
	}
}
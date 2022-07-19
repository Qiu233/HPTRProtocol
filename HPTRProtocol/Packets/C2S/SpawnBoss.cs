namespace HPTRProtocol.Packets.C2S;

public class SpawnBoss : Packet, IOtherPlayerSlot
{
    public override MessageID Type => MessageID.SpawnBoss;
    public byte OtherPlayerSlot { get; set; }
    public byte HighBitOfPlayerIsAlwaysZero { get; set; } = 0;
    public short NPCType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		OtherPlayerSlot = br.ReadByte();
		HighBitOfPlayerIsAlwaysZero = br.ReadByte();
		NPCType = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(OtherPlayerSlot);
		bw.Write(HighBitOfPlayerIsAlwaysZero);
		bw.Write(NPCType);
	}
}
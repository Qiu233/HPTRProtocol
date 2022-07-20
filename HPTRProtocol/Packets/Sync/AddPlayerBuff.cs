namespace HPTRProtocol.Packets.Sync;

public class AddPlayerBuff : Packet, IOtherPlayerSlot
{
	public override MessageID Type => MessageID.AddPlayerBuff;
	public byte OtherPlayerSlot { get; set; }
	public Buff<int> Buff { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		OtherPlayerSlot = br.ReadByte();
		Buff = br.ReadSerializable<Buff<int>>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(OtherPlayerSlot);
		bw.WriteSerializable(Buff);
	}
}
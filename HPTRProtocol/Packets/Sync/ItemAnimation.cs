namespace HPTRProtocol.Packets.Sync;

public class ItemAnimation : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.ItemAnimation;
	public byte PlayerSlot { get; set; }
	public float Rotation { get; set; }
	public short Animation { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Rotation = br.ReadSingle();
		Animation = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Rotation);
		bw.Write(Animation);
	}
}
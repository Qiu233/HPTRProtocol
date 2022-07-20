namespace HPTRProtocol.Packets.Sync;

public class UpdateSign : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.UpdateSign;
	public short SignSlot { get; set; }
	public ShortPosition Position { get; set; }
	public string Text { get; set; }
	public byte PlayerSlot { get; set; }
	public byte SignFlags { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		SignSlot = br.ReadInt16();
		Position = br.ReadSerializable<ShortPosition>();
		Text = br.ReadString();
		PlayerSlot = br.ReadByte();
		SignFlags = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(SignSlot);
		bw.WriteSerializable(Position);
		bw.Write(Text);
		bw.Write(PlayerSlot);
		bw.Write(SignFlags);
	}
}
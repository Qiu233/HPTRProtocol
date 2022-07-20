namespace HPTRProtocol.Packets.Sync;

public class ChestName : Packet
{
    public override MessageID Type => MessageID.ChestName;
    public short ChestSlot { get; set; }
    public ShortPosition Position { get; set; }
    public string Name { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ChestSlot = br.ReadInt16();
		Position = br.ReadSerializable<ShortPosition>();
		Name = br.ReadString();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ChestSlot);
		bw.WriteSerializable(Position);
		bw.Write(Name);
	}
}
namespace HPTRProtocol.Packets.Sync;

public class PlaceChest : Packet
{
	public override MessageID Type => MessageID.PlaceChest;
	public byte Action { get; set; }
	public ShortPosition Position { get; set; }
	public short Style { get; set; }
	/// <summary>
	/// Only populated meaningful value when sent from server, otherwise 0.
	/// </summary>
	public short ChestIDToDestroy { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Action = br.ReadByte();
		Position = br.ReadSerializable<ShortPosition>();
		Style = br.ReadInt16();
		ChestIDToDestroy = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Action);
		bw.WriteSerializable(Position);
		bw.Write(Style);
		bw.Write(ChestIDToDestroy);
	}
}
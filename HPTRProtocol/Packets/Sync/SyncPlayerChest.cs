using DotNext;

namespace HPTRProtocol.Packets.Sync;

public class SyncPlayerChest : Packet
{
	public override MessageID Type => MessageID.SyncPlayerChest;
	public short Chest { get; set; }
	public ShortPosition Position { get; set; }
	public Optional<string> ChestName { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Chest = br.ReadInt16();
		Position = br.ReadS<ShortPosition>();
		byte len = br.ReadByte();
		if (len > 0 && len <= 20)
			ChestName = br.ReadString();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Chest);
		bw.WriteS(Position);
		if (!ChestName.TryGet(out string v) || v.Length == 0 || v.Length > 20)
		{
			bw.Write((byte)255);
			return;
		}
		bw.Write((byte)v.Length);
		bw.Write(v);
	}
}
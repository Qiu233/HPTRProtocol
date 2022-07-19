using DotNext;

namespace HPTRProtocol.Packets.Sync;

public class SyncActiveChest : Packet
{
	public override MessageID Type => MessageID.SyncActiveChest;
	public short Chest { get; set; }
	public Position<short> Position { get; set; }
	public Optional<string> ChestName { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Chest = br.ReadInt16();
		Position = br.ReadS<Position<short>>();
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
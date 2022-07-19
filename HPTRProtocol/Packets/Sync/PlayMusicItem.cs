namespace HPTRProtocol.Packets.Sync;

public class PlayMusicItem : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.PlayMusicItem;
	public byte PlayerSlot { get; set; }
	public float Range { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Range = br.ReadSingle();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Range);
	}
}
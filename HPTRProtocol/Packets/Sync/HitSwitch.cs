namespace HPTRProtocol.Packets.Sync;

public class HitSwitch : Packet
{
	public override MessageID Type => MessageID.HitSwitch;
	public ShortPosition Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadSerializable<ShortPosition>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteSerializable(Position);
}
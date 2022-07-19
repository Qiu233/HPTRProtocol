namespace HPTRProtocol.Packets.Sync;

public class HitSwitch : Packet
{
	public override MessageID Type => MessageID.HitSwitch;
	public Position<short> Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadS<Position<short>>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteS(Position);
}
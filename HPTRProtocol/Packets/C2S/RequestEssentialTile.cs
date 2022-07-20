namespace HPTRProtocol.Packets.C2S;

public class RequestEssentialTile : Packet
{
	public override MessageID Type => MessageID.RequestEssentialTile;
	public Position Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadSerializable<Position>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteSerializable(Position);
}

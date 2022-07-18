namespace HPTRProtocol.Packets.C2S;

public class RequestTileData : Packet
{
	public override MessageID Type => MessageID.RequestTileData;
	public Position Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadS<Position>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteS(Position);
}

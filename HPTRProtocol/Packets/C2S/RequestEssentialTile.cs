namespace HPTRProtocol.Packets.C2S;

public class RequestEssentialTile : Packet
{
	public override MessageID Type => MessageID.RequestEssentialTile;
	public Position<int> Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Position = br.ReadS<Position<int>>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteS(Position);
}

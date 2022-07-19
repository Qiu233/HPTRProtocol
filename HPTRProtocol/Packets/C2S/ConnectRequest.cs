namespace HPTRProtocol.Packets.C2S;

public class ConnectRequest : Packet
{
	public override MessageID Type => MessageID.ConnectRequest;
	public string Version { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Version = br.ReadString();

	protected override void SerializeOverride(BinaryWriter bw) => bw.Write(Version);
}

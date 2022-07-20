namespace HPTRProtocol.Packets.C2S;

public class ClientUUID : Packet
{
	public override MessageID Type => MessageID.ClientUUID;
	public string UUID { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		UUID = br.ReadString();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(UUID);
	}
}
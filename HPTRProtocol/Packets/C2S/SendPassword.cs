namespace HPTRProtocol.Packets.C2S;

public class SendPassword : Packet
{
	public override MessageID Type => MessageID.SendPassword;
	public string Password { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Password = br.ReadString();

	protected override void SerializeOverride(BinaryWriter bw) => bw.Write(Password);
}

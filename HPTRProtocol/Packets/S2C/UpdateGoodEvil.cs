namespace HPTRProtocol.Packets.S2C;

public class UpdateGoodEvil : Packet
{
    public override MessageID Type => MessageID.UpdateGoodEvil;
    public byte Good { get; set; }
    public byte Evil { get; set; }
    public byte Blood { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Good = br.ReadByte();
		Evil = br.ReadByte();
		Blood = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Good);
		bw.Write(Evil);
		bw.Write(Blood);
	}
}
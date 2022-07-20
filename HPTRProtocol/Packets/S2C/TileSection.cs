namespace HPTRProtocol.Packets.S2C;

public class TileSection : Packet
{
	public override MessageID Type => MessageID.TileSection;
	public SectionData Data { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Data = br.ReadSerializable<SectionData>();

	protected override void SerializeOverride(BinaryWriter bw) => bw.WriteSerializable(Data);
}

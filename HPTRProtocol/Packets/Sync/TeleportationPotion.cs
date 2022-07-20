namespace HPTRProtocol.Packets.Sync;

public class TeleportationPotion : Packet
{
    public override MessageID Type => MessageID.TeleportationPotion;
    public byte Style { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => Style = br.ReadByte();

	protected override void SerializeOverride(BinaryWriter bw) => bw.Write(Style);
}
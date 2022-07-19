namespace HPTRProtocol.Packets.S2C;

public class RemoveItemOwner : Packet, IItemSlot
{
	public override MessageID Type => MessageID.RemoveItemOwner;
	public short ItemSlot { get; set; }

	protected override void DeserializeOverride(BinaryReader br) => ItemSlot = br.ReadInt16();

	protected override void SerializeOverride(BinaryWriter bw) => bw.Write(ItemSlot);
}
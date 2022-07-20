namespace HPTRProtocol.Packets.S2C;

public class TravelMerchantItems : Packet
{
	public override MessageID Type => MessageID.TravelMerchantItems;
	public short[] ShopItems { get; } = new short[ShopItemsLength];
	public const int ShopItemsLength = 40;

	protected override void DeserializeOverride(BinaryReader br)
	{
		for (int i = 0; i < ShopItems.Length; i++)
			ShopItems[i] = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		for (int i = 0; i < ShopItems.Length; i++)
			bw.Write(ShopItems[i]);
	}
}
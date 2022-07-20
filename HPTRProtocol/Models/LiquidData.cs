namespace HPTRProtocol.Models;

public struct LiquidData : ISerializable
{
	public ushort TotalChanges { get; set; }
	public LiquidChange[] LiquidChanges { get; set; }

	public void Deserialize(BinaryReader br)
	{
		TotalChanges = br.ReadUInt16();
		LiquidChanges = new LiquidChange[TotalChanges];
		for (int i = 0; i < LiquidChanges.Length; i++)
			LiquidChanges[i] = br.ReadSerializable<LiquidChange>();
	}

	public void Serialize(BinaryWriter bw)
	{
		if (LiquidChanges is null || LiquidChanges.Length != TotalChanges)
			throw new Exception("Unexpected length of LiquidChanges");
		bw.Write(TotalChanges);
		for (int i = 0; i < LiquidChanges.Length; i++)
			bw.WriteSerializable(LiquidChanges[i]);
	}
}

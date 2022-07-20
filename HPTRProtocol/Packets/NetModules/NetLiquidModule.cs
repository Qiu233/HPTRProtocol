namespace HPTRProtocol.Packets.NetModules;

public class NetLiquidModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetLiquidModule;
	public LiquidData LiquidChanges { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		LiquidChanges = br.ReadSerializable<LiquidData>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(LiquidChanges);
	}
}
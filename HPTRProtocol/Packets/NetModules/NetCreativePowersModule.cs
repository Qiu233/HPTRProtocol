namespace HPTRProtocol.Packets.NetModules;

public class NetCreativePowersModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetCreativePowersModule;
	public CreativePowerTypes PowerType { get; set; }
	public byte[] Data { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PowerType = br.ReadEnum<CreativePowerTypes>();
		Data = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteEnum(PowerType);
		bw.Write(Data);
	}
}
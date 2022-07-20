namespace HPTRProtocol.Packets.NetModules;


public class NetCreativePowerPermissionsModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetCreativePowerPermissionsModule;
	public byte AlwaysZero { get; set; } = 0;
	public ushort PowerId { get; set; }
	public byte Level { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		AlwaysZero = br.ReadByte();
		PowerId = br.ReadUInt16();
		Level = br.ReadByte();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(AlwaysZero);
		bw.Write(PowerId);
		bw.Write(Level);
	}
}
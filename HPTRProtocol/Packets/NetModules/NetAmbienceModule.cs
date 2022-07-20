namespace HPTRProtocol.Packets.NetModules;


public class NetAmbienceModule : NetModulesPacket, IPlayerSlot
{
	public override NetModuleType ModuleType => NetModuleType.NetAmbienceModule;
	public byte PlayerSlot { get; set; }
	public int Random { get; set; }
	public SkyEntityType SkyType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Random = br.ReadInt32();
		SkyType = br.ReadEnum<SkyEntityType>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Random);
		bw.WriteEnum(SkyType);
	}
}
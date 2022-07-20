namespace HPTRProtocol.Packets.NetModules;

public class NetTeleportPylonModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetTeleportPylonModule;
	public PylonPacketType PylonPacketType { get; set; }
	public ShortPosition Position { get; set; }
	public TeleportPylonType PylonType { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PylonPacketType = br.ReadEnum<PylonPacketType>();
		Position = br.ReadSerializable<ShortPosition>();
		PylonType= br.ReadEnum<TeleportPylonType>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteEnum(PylonPacketType);
		bw.WriteSerializable(Position);
		bw.WriteEnum(PylonType);
	}
}
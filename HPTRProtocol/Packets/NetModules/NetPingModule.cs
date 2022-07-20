namespace HPTRProtocol.Packets.NetModules;


public class NetPingModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetPingModule;
	public Vector2 Position { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadSerializable<Vector2>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Position);
	}
}
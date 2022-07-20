namespace HPTRProtocol.Packets.NetModules;

public class NetParticlesModule : NetModulesPacket
{
    public override NetModuleType ModuleType => NetModuleType.NetParticlesModule;
    public ParticleOrchestraType ParticleType { get; set; }
    public ParticleOrchestraSettings Settings { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ParticleType = br.ReadEnum<ParticleOrchestraType>();
		Settings = br.ReadSerializable<ParticleOrchestraSettings>();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteEnum(ParticleType);
		bw.WriteSerializable(Settings);
	}
}
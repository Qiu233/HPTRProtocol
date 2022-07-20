using DotNext;

namespace HPTRProtocol.Packets.NetModules;


public class NetTextModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetTextModule;
	public byte[] Data { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Data = br.ReadBytes((int)(br.BaseStream.Length - br.BaseStream.Position));
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Data);
	}
}
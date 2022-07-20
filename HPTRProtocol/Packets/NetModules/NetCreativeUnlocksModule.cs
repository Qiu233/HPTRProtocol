namespace HPTRProtocol.Packets.NetModules;

public class NetCreativeUnlocksModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetCreativeUnlocksModule;
	public short ItemId { get; set; }
	public ushort Count { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		ItemId = br.ReadInt16();
		Count = br.ReadUInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(ItemId);
		bw.Write(Count);
	}
}
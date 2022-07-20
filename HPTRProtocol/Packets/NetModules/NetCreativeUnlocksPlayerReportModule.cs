namespace HPTRProtocol.Packets.NetModules;

public class NetCreativeUnlocksPlayerReportModule : NetModulesPacket
{
	public override NetModuleType ModuleType => NetModuleType.NetCreativeUnlocksPlayerReportModule;
	public byte AlwaysZero { get; set; } = 0;
	public ushort ItemId { get; set; }
	public ushort Count { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		AlwaysZero = br.ReadByte();
		ItemId = br.ReadUInt16();
		Count = br.ReadUInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(AlwaysZero);
		bw.Write(ItemId);
		bw.Write(Count);
	}
}
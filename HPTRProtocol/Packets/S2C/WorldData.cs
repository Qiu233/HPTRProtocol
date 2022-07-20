namespace HPTRProtocol.Packets.S2C;

public class WorldData : Packet
{
	public override MessageID Type => MessageID.WorldData;
	public int Time { get; set; }
	public BitsByte DayAndMoonInfo { get; set; }
	public byte MoonPhase { get; set; }
	public short MaxTileX { get; set; }
	public short MaxTileY { get; set; }
	public short SpawnX { get; set; }
	public short SpawnY { get; set; }
	public short WorldSurface { get; set; }
	public short RockLayer { get; set; }
	public int WorldID { get; set; }
	public string WorldName { get; set; }
	public byte GameMode { get; set; }
	public Guid WorldUniqueID { get; set; }
	public ulong WorldGeneratorVersion { get; set; }
	public byte MoonType { get; set; }
	public byte TreeBackground1 { get; set; }
	public byte TreeBackground2 { get; set; }
	public byte TreeBackground3 { get; set; }
	public byte TreeBackground4 { get; set; }
	public byte CorruptionBackground { get; set; }
	public byte JungleBackground { get; set; }
	public byte SnowBackground { get; set; }
	public byte HallowBackground { get; set; }
	public byte CrimsonBackground { get; set; }
	public byte DesertBackground { get; set; }
	public byte OceanBackground { get; set; }
	public byte MushroomBackground { get; set; }
	public byte UnderworldBackground { get; set; }
	public byte IceBackStyle { get; set; }
	public byte JungleBackStyle { get; set; }
	public byte HellBackStyle { get; set; }
	public float WindSpeedSet { get; set; }
	public byte CloudNumber { get; set; }
	public int TreeX_1 { get; set; }
	public int TreeX_2 { get; set; }
	public int TreeX_3 { get; set; }
	public byte TreeStyle_1 { get; set; }
	public byte TreeStyle_2 { get; set; }
	public byte TreeStyle_3 { get; set; }
	public byte TreeStyle_4 { get; set; }
	public int CaveBackX_1 { get; set; }
	public int CaveBackX_2 { get; set; }
	public int CaveBackX_3 { get; set; }
	public byte CaveBackStyle_1 { get; set; }
	public byte CaveBackStyle_2 { get; set; }
	public byte CaveBackStyle_3 { get; set; }
	public byte CaveBackStyle_4 { get; set; }
	TreeTopsVariations TreeTopsVariations { get; set; }
	public float Rain { get; set; }
	public BitsByte EventInfo1 { get; set; }
	public BitsByte EventInfo2 { get; set; }
	public BitsByte EventInfo3 { get; set; }
	public BitsByte EventInfo4 { get; set; }
	public BitsByte EventInfo5 { get; set; }
	public BitsByte EventInfo6 { get; set; }
	public BitsByte EventInfo7 { get; set; }
	public BitsByte EventInfo8 { get; set; }
	public short CopperOreTier { get; set; }
	public short IronOreTier { get; set; }
	public short SilverOreTier { get; set; }
	public short GoldOreTier { get; set; }
	public short CobaltOreTier { get; set; }
	public short MythrilOreTier { get; set; }
	public short AdamantiteOreTier { get; set; }
	public sbyte InvasionType { get; set; }
	public ulong LobbyID { get; set; }
	public float SandstormSeverity { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Time = br.ReadInt32();
		DayAndMoonInfo = br.ReadByte();
		MoonPhase = br.ReadByte();

		MaxTileX = br.ReadInt16();
		MaxTileY = br.ReadInt16();
		SpawnX = br.ReadInt16();
		SpawnY = br.ReadInt16();
		WorldSurface = br.ReadInt16();
		RockLayer = br.ReadInt16();

		WorldID = br.ReadInt32();
		WorldName = br.ReadString();
		GameMode = br.ReadByte();

		WorldUniqueID = br.ReadValue<Guid>();
		WorldGeneratorVersion = br.ReadUInt64();

		MoonType = br.ReadByte();

		TreeBackground1 = br.ReadByte();
		TreeBackground2 = br.ReadByte();
		TreeBackground3 = br.ReadByte();
		TreeBackground4 = br.ReadByte();

		CorruptionBackground = br.ReadByte();
		JungleBackground = br.ReadByte();
		SnowBackground = br.ReadByte();
		HallowBackground = br.ReadByte();
		CrimsonBackground = br.ReadByte();
		DesertBackground = br.ReadByte();
		OceanBackground = br.ReadByte();
		MushroomBackground = br.ReadByte();
		UnderworldBackground = br.ReadByte();

		IceBackStyle = br.ReadByte();
		JungleBackStyle = br.ReadByte();
		HellBackStyle = br.ReadByte();

		WindSpeedSet = br.ReadSingle();

		CloudNumber = br.ReadByte();

		TreeX_1 = br.ReadInt32();
		TreeX_2 = br.ReadInt32();
		TreeX_3 = br.ReadInt32();

		TreeStyle_1 = br.ReadByte();
		TreeStyle_2 = br.ReadByte();
		TreeStyle_3 = br.ReadByte();
		TreeStyle_4 = br.ReadByte();

		CaveBackX_1 = br.ReadInt32();
		CaveBackX_2 = br.ReadInt32();
		CaveBackX_3 = br.ReadInt32();

		CaveBackStyle_1 = br.ReadByte();
		CaveBackStyle_2 = br.ReadByte();
		CaveBackStyle_3 = br.ReadByte();
		CaveBackStyle_4 = br.ReadByte();

		TreeTopsVariations = br.ReadSerializable<TreeTopsVariations>();

		Rain = br.ReadSingle();

		EventInfo1 = br.ReadByte();
		EventInfo2 = br.ReadByte();
		EventInfo3 = br.ReadByte();
		EventInfo4 = br.ReadByte();
		EventInfo5 = br.ReadByte();
		EventInfo6 = br.ReadByte();
		EventInfo7 = br.ReadByte();
		EventInfo8 = br.ReadByte();

		CopperOreTier = br.ReadInt16();
		IronOreTier = br.ReadInt16();
		SilverOreTier = br.ReadInt16();
		GoldOreTier = br.ReadInt16();
		CobaltOreTier = br.ReadInt16();
		MythrilOreTier = br.ReadInt16();
		AdamantiteOreTier = br.ReadInt16();

		InvasionType = br.ReadSByte();
		LobbyID = br.ReadUInt64();
		SandstormSeverity = br.ReadSingle();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(Time);
		bw.Write(DayAndMoonInfo);
		bw.Write(MoonPhase);

		bw.Write(MaxTileX);
		bw.Write(MaxTileY);
		bw.Write(SpawnX);
		bw.Write(SpawnY);
		bw.Write(WorldSurface);
		bw.Write(RockLayer);

		bw.Write(WorldID);
		bw.Write(WorldName);
		bw.Write(GameMode);

		bw.WriteValue(WorldUniqueID);
		bw.Write(WorldGeneratorVersion);

		bw.Write(MoonType);

		bw.Write(TreeBackground1);
		bw.Write(TreeBackground2);
		bw.Write(TreeBackground3);
		bw.Write(TreeBackground4);

		bw.Write(CorruptionBackground);
		bw.Write(JungleBackground);
		bw.Write(SnowBackground);
		bw.Write(HallowBackground);
		bw.Write(CrimsonBackground);
		bw.Write(DesertBackground);
		bw.Write(OceanBackground);
		bw.Write(MushroomBackground);
		bw.Write(UnderworldBackground);

		bw.Write(IceBackStyle);
		bw.Write(JungleBackStyle);
		bw.Write(HellBackStyle);

		bw.Write(WindSpeedSet);

		bw.Write(CloudNumber);

		bw.Write(TreeX_1);
		bw.Write(TreeX_2);
		bw.Write(TreeX_3);

		bw.Write(TreeStyle_1);
		bw.Write(TreeStyle_2);
		bw.Write(TreeStyle_3);
		bw.Write(TreeStyle_4);

		bw.Write(CaveBackX_1);
		bw.Write(CaveBackX_2);
		bw.Write(CaveBackX_3);

		bw.Write(CaveBackStyle_1);
		bw.Write(CaveBackStyle_2);
		bw.Write(CaveBackStyle_3);
		bw.Write(CaveBackStyle_4);

		bw.WriteSerializable(TreeTopsVariations);

		bw.Write(Rain);

		bw.Write(EventInfo1);
		bw.Write(EventInfo2);
		bw.Write(EventInfo3);
		bw.Write(EventInfo4);
		bw.Write(EventInfo5);
		bw.Write(EventInfo6);
		bw.Write(EventInfo7);
		bw.Write(EventInfo8);

		bw.Write(CopperOreTier);
		bw.Write(IronOreTier);
		bw.Write(SilverOreTier);
		bw.Write(GoldOreTier);
		bw.Write(CobaltOreTier);
		bw.Write(MythrilOreTier);
		bw.Write(AdamantiteOreTier);

		bw.Write(InvasionType);
		bw.Write(LobbyID);
		bw.Write(SandstormSeverity);
	}
}

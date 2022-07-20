using HPTRProtocol.Packets.NetModules;

namespace PacketTests;

public class NetModuleTests
{
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetAmbienceModuleTest()
	{
		ClientSerializeTest(
			new NetAmbienceModule
			{
				PlayerSlot = 20,
				Random = 6,
				SkyType = SkyEntityType.Meteor,
			}
			, new byte[] { 0x0B, 0x00, 0x52, 0x03, 0x00, 0x14, 0x06, 0x00, 0x00, 0x00, 0x05 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetBestiaryModuleTest()//TODO: complete this test
	{
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetCreativePowerPermissionsModuleTest()
	{
		ClientSerializeTest(
			new NetCreativePowerPermissionsModule
			{
				Level = 2,
				PowerId = 7
			}
			, new byte[] { 0x09, 0x00, 0x52, 0x0A, 0x00, 0x00, 0x07, 0x00, 0x02 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetCreativePowersModuleTest()//TODO: complete this test
	{
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetCreativeUnlocksModuleTest()
	{
		ClientSerializeTest(
			new NetCreativeUnlocksModule
			{
				ItemId = 3063,
				Count = 20
			}
			, new byte[] { 0x09, 0x00, 0x52, 0x05, 0x00, 0xF7, 0x0B, 0x14, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetCreativeUnlocksPlayerReportModuleTest()
	{
		ClientSerializeTest(
			new NetCreativeUnlocksPlayerReportModule
			{
				ItemId = 3063,
				Count = 20
			}
			, new byte[] { 0x0A, 0x00, 0x52, 0x07, 0x00, 0x00, 0xF7, 0x0B, 0x14, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetLiquidModuleTest()
	{
		ClientSerializeTest(
			new NetLiquidModule
			{
				LiquidChanges = new LiquidData
				{
					TotalChanges = 2,
					LiquidChanges = new LiquidChange[]
					{
						new LiquidChange
						{
							Position = new Position<short>(500,600),
							LiquidAmount = 20,
							LiquidType = LiquidType.Honey
						},
						new LiquidChange
						{
							Position = new Position<short>(900,1000),
							LiquidAmount = 50,
							LiquidType = LiquidType.Water
						}
					}
				}
			}
			, new byte[] { 0x13, 0x00, 0x52, 0x00, 0x00, 0x02, 0x00, 0xF4, 0x01, 0x58, 0x02, 0x14, 0x03, 0x84, 0x03, 0xE8, 0x03, 0x32, 0x01 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetParticlesModuleTest()
	{
		ClientSerializeTest(
			new NetParticlesModule
			{
				ParticleType = ParticleOrchestraType.StellarTune,
				Settings = new ParticleOrchestraSettings
				{
					IndexOfPlayerWhoInvokedThis = 7,
					MovementVector = new(20, 30),
					PackedShaderIndex = 0,
					PositionInWorld = new(500, 600)
				}
			}
			, new byte[] {
				0x1B, 0x00, 0x52, 0x09, 0x00, 0x02, 0x00, 0x00, 0xFA, 0x43, 0x00, 0x00, 0x16,
				0x44, 0x00, 0x00, 0xA0, 0x41, 0x00, 0x00, 0xF0, 0x41, 0x00, 0x00, 0x00, 0x00, 0x07 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetPingModuleTest()
	{
		ClientSerializeTest(
			new NetPingModule
			{
				Position = new(900, 1000)
			}
			, new byte[] { 0x0D, 0x00, 0x52, 0x02, 0x00, 0x00, 0x00, 0x61, 0x44, 0x00, 0x00, 0x7A, 0x44 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void NetTeleportPylonModuleTest()
	{
		ClientSerializeTest(
			new NetTeleportPylonModule
			{
				Position = new(8000, 9000),
				PylonPacketType = PylonPacketType.PlayerRequestsTeleport,
				PylonType = TeleportPylonType.Snow
			}
			, new byte[] { 0x0B, 0x00, 0x52, 0x08, 0x00, 0x02, 0x40, 0x1F, 0x28, 0x23, 0x06 }
		);
	}
}
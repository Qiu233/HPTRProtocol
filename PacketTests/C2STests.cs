namespace PacketTests;

public class C2STests
{
	[TestedFor("1.4.3.6")]
	[Fact]
	public void ConnectRequestTest()
	{
		ClientSerializeTest(
			new ConnectRequest
			{
				Version = "Terraria248"
			}
			, new byte[] { 0x0f, 0x00, 0x01, 0x0b, 0x54, 0x65, 0x72, 0x72, 0x61, 0x72, 0x69, 0x61, 0x32, 0x34, 0x38 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void RequestChestOpenTest()
	{
		ClientSerializeTest(
			new RequestChestOpen
			{
				Position = new(20, 40)
			}
			, new byte[] { 0x07, 0x00, 0x1F, 0x14, 0x00, 0x28, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void RequestEssentialTileTest()
	{
		ClientSerializeTest(
			new RequestEssentialTile
			{
				Position = new(20, 40)
			}
			, new byte[] { 0x0B, 0x00, 0x08, 0x14, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void SpawnPlayerTest()
	{
		ClientSerializeTest(
			new SpawnPlayer
			{
				PlayerSlot = 0,
				Position = new(20, 40),
				Timer = 20,
				Context = PlayerSpawnContext.ReviveFromDeath
			}
			, new byte[] { 0x0D, 0x00, 0x0C, 0x00, 0x14, 0x00, 0x28, 0x00, 0x14, 0x00, 0x00, 0x00, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void RequestSignTest()
	{
		ClientSerializeTest(
			new RequestSign
			{
				Position = new(50, 60)
			}
			, new byte[] { 0x07, 0x00, 0x2E, 0x32, 0x00, 0x3C, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SendPasswordTest()
	{
		ClientSerializeTest(
			new SendPassword
			{
				Password = "abc123"
			}
			, new byte[] { 0x0A, 0x00, 0x26, 0x06, 0x61, 0x62, 0x63, 0x31, 0x32, 0x33 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SpawnBossTest()
	{
		ClientSerializeTest(
			new SpawnBoss
			{
				OtherPlayerSlot = 20,
				NPCType = 50
			}
			, new byte[] { 0x07, 0x00, 0x3D, 0x14, 0x00, 0x32, 0x00 }
		);
	}
}
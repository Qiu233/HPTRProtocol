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
	public void RequestTileDataTest()
	{
		ClientSerializeTest(
			new RequestTileData
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
}
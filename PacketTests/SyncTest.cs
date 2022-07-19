namespace PacketTests;

public class SyncTest
{
	[TestedFor("1.4.3.6")]
	[Fact]
	public void DoorToggletTest()
	{
		ClientSerializeTest(
			new DoorToggle
			{
				ChangeType = true,
				Position = new(20, 40),
				Direction = 2
			}
			, new byte[] { 0x09, 0x00, 0x13, 0x01, 0x14, 0x00, 0x28, 0x00, 0x02 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void InstancedItemTest()
	{
		ClientSerializeTest(
			new InstancedItem
			{
				ItemSlot = 2,
				Position = new(20, 40),
				Velocity = new(20, 40),
				Stack = 20,
				Prefix = 6,
				Owner = 4,
				ItemType = 3063
			}
			, new byte[] {
				0x1B, 0x00, 0x5A, 0x02, 0x00, 0x00, 0x00, 0xA0, 0x41, 0x00, 0x00, 0x20, 0x42,
				0x00, 0x00, 0xA0, 0x41, 0x00, 0x00, 0x20, 0x42, 0x14, 0x00, 0x06, 0x04, 0xF7, 0x0B }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void ItemOwnerTest()
	{
		ClientSerializeTest(
			new SyncItemOwner
			{
				ItemSlot = 20,
				OtherPlayerSlot = 5
			}
			, new byte[] { 0x06, 0x00, 0x16, 0x14, 0x00, 0x05 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void KillProjectileTest()
	{
		ClientSerializeTest(
			new KillProjectile
			{
				PlayerSlot = 10,
				ProjSlot = 20
			}
			, new byte[] { 0x06, 0x00, 0x1D, 0x14, 0x00, 0x0A }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerControlsTest()
	{
		ClientSerializeTest(
			new UpdatePlayer
			{
				PlayerSlot = 20,
				Bit1 = 2,
				Bit2 = 3,
				Bit3 = 4,
				Bit4 = 5,
				SelectedItem = 20,
				Position = new(20, 40),
				Velocity = new(20, 40),
				PotionOfReturnOriginalUsePosition = new(20, 40),
				PotionOfReturnHomePosition = new(20, 40)
			}
			, new byte[] { 0x11, 0x00, 0x0D, 0x14, 0x02, 0x03, 0x04, 0x05, 0x14, 0x00, 0x00, 0xA0, 0x41, 0x00, 0x00, 0x20, 0x42 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerHealthTest()
	{
		ClientSerializeTest(
			new PlayerHealth
			{
				PlayerSlot = 16,
				StatLifeMax = 200,
				StatLife = 20
			}
			, new byte[] { 0x08, 0x00, 0x10, 0x10, 0x14, 0x00, 0xC8, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerPvPTest()
	{
		ClientSerializeTest(
			new PlayerPvP
			{
				PlayerSlot = 10,
				Pvp = true
			}
			, new byte[] { 0x05, 0x00, 0x1E, 0x0A, 0x01 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void StrikeNPCTest()
	{
		ClientSerializeTest(
			new StrikeNPC
			{
				NPCSlot = 12,
				Crit = true,
				Damage = 200,
				HitDirection = 3,
				Knockback = 2f
			}
			, new byte[] { 0x0D, 0x00, 0x1C, 0x0C, 0x00, 0xC8, 0x00, 0x00, 0x00, 0x00, 0x40, 0x03, 0x01 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncChestItemTest()
	{
		ClientSerializeTest(
			new SyncChestItem
			{
				ChestSlot = 10,
				ChestItemSlot = 20,
				ItemType = 3064,
				Prefix = 8,
				Stack = 1,
			}
			, new byte[] { 0x0B, 0x00, 0x20, 0x0A, 0x00, 0x14, 0x01, 0x00, 0x08, 0xF8, 0x0B }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncEquipmentTest()
	{
		ClientSerializeTest(
			new SyncPlayerInvSlot
			{
				PlayerSlot = 7,
				ItemSlot = 20,
				ItemType = 3062,
				Prefix = 7,
				Stack = 2
			}
			, new byte[] { 0x0B, 0x00, 0x05, 0x07, 0x14, 0x00, 0x02, 0x00, 0x07, 0xF6, 0x0B }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncItemTest()
	{
		ClientSerializeTest(
			new SyncItemDrop
			{
				ItemSlot = 30,
				ItemType = 20,
				Owner = 6,
				Position = new(520, 540),
				Velocity = new(20, 40),
				Prefix = 4,
				Stack = 2,
			}
			, new byte[] {
				0x1B, 0x00, 0x15, 0x1E, 0x00, 0x00, 0x00, 0x02, 0x44,
				0x00, 0x00, 0x07, 0x44, 0x00, 0x00, 0xA0, 0x41, 0x00,
				0x00, 0x20, 0x42, 0x02, 0x00, 0x04, 0x06, 0x14, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncNPCTest()
	{
		ClientSerializeTest(
			new SyncNPC
			{
				NPCSlot = 17,
				NPCType = 60,
				AI1 = 1f,
				AI2 = 2f,
				AI3 = 3f,
				AI4 = 4f,
				Bit1 = 2,
				Bit2 = 3,
				Bit3 = 4,
				HP = 200,
				Target = 20,
				PlayerCount = 10,
				Offset = new(40, 80),
				Velocity = new(80, 40),
				StrengthMultiplier = 2f
			}
			, new byte[] {
				0x21, 0x00, 0x17, 0x11, 0x00, 0x00, 0x00, 0x20, 0x42, 0x00, 0x00,
				0xA0, 0x42, 0x00, 0x00, 0xA0, 0x42, 0x00, 0x00, 0x20, 0x42, 0x14,
				0x00, 0x02, 0x03, 0x3C, 0x00, 0x0A, 0x04, 0xC8, 0x00, 0x00, 0x00 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncPlayerTest()
	{
		ClientSerializeTest(
			new SyncPlayerInfo
			{
				PlayerSlot = 2,
				SkinVariant = 6,
				Hair = 20,
				Name = "TestPlayerName",
				HairDye = 6,
				Bit1 = 4,
				Bit2 = 6,
				Bit3 = 25,
				Bit4 = 90,
				HideMisc = 20,
				HairColor = new(20, 20, 20),
				SkinColor = new(30, 30, 30),
				EyeColor = new(40, 30, 30),
				ShirtColor = new(50, 30, 30),
				UnderShirtColor = new(60, 30, 30),
				PantsColor = new(70, 30, 30),
				ShoeColor = new(80, 30, 30),
			}
			, new byte[] {
				0x30, 0x00, 0x04, 0x02, 0x06, 0x14, 0x0E, 0x54, 0x65, 0x73, 0x74, 0x50,
				0x6C, 0x61, 0x79, 0x65, 0x72, 0x4E, 0x61, 0x6D, 0x65, 0x06, 0x04, 0x06,
				0x14, 0x14, 0x14, 0x14, 0x1E, 0x1E, 0x1E, 0x28, 0x1E, 0x1E, 0x32, 0x1E,
				0x1E, 0x3C, 0x1E, 0x1E, 0x46, 0x1E, 0x1E, 0x50, 0x1E, 0x1E, 0x19, 0x5A }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncPlayerChestTest() //TODO: need further test on ChestName
	{
		ClientSerializeTest(
			new SyncActiveChest
			{
				Chest = 20,
				Position = new(80, 120)
			}
			, new byte[] { 0x0A, 0x00, 0x21, 0x14, 0x00, 0x50, 0x00, 0x78, 0x00, 0xFF }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncProjectileTest()
	{
		ClientSerializeTest(
			new SyncProjectile
			{
				ProjSlot = 23,
				Position = new(70, 80),
				Velocity = new(70, 80),
				PlayerSlot = 20,
				ProjType = 50,
				Bit1 = 50,
				AI1 = 2f,
				AI2 = 6f,
				BannerId = 6,
				Damange = 600,
				Knockback = 2f,
				OriginalDamage = 500,
				UUID = 42
			}
			, new byte[] {
				0x23, 0x00, 0x1B, 0x17, 0x00, 0x00, 0x00, 0x8C, 0x42, 0x00, 0x00, 0xA0,
				0x42, 0x00, 0x00, 0x8C, 0x42, 0x00, 0x00, 0xA0, 0x42, 0x14, 0x32, 0x00,
				0x32, 0x00, 0x00, 0xC0, 0x40, 0x58, 0x02, 0x00, 0x00, 0x00, 0x40 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void TileChangeTest()
	{
		ClientSerializeTest(
			new TileChange
			{
				ChangeType = 2,
				Position = new(60, 90),
				Style = 5,
				TileType = 60
			}
			, new byte[] { 0x0B, 0x00, 0x11, 0x02, 0x3C, 0x00, 0x5A, 0x00, 0x3C, 0x00, 0x05 }
		);
	}
	[TestedFor("1.4.3.6")]
	[Fact]
	public void TileSquareTest()
	{
		ClientSerializeTest(
			new TileSquare
			{
				Data = new SquareData()
				{
					ChangeType = TileChangeType.LavaWater,
					TilePosX = 20,
					TilePosY = 40,
					Width = 60,
					Height = 80,
					Tiles = new SimpleTileData[5, 10],
				}
			}
			, new byte[] {
				0x6E, 0x00, 0x14, 0x14, 0x00, 0x28, 0x00, 0x3C, 0x50, 0x01, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }
		);
	}


	[TestedFor("1.4.3.6")]
	[Fact]
	public void ActiveNPCTest()
	{
		ClientSerializeTest(
			new ActiveNPC
			{
				NPCSlot = 20,
				PlayerSlot = 40
			}
			, new byte[] { 0x06, 0x00, 0x28, 0x28, 0x14, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void AddNPCBuffTest()
	{
		ClientSerializeTest(
			new AddNPCBuff
			{
				BuffType = 40,
				BuffTime = 1800
			}
			, new byte[] { 0x09, 0x00, 0x35, 0x00, 0x00, 0x28, 0x00, 0x08, 0x07 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void AddPlayerBuffTest()
	{
		ClientSerializeTest(
			new AddPlayerBuff
			{
				OtherPlayerSlot = 20,
				Buff = new() { Type = 60, Time = 3600 }
			}
			, new byte[] { 0x0A, 0x00, 0x37, 0x14, 0x3C, 0x00, 0x10, 0x0E, 0x00, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void DodgeTest()
	{
		ClientSerializeTest(
			new Dodge
			{
				PlayerSlot = 20,
				DodgeType = 6
			}
			, new byte[] { 0x05, 0x00, 0x3E, 0x14, 0x06 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void HealEffectTest()
	{
		ClientSerializeTest(
			new HealEffect
			{
				PlayerSlot = 6,
				Amount = 500
			}
			, new byte[] { 0x06, 0x00, 0x23, 0x06, 0xF4, 0x01 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void HealOtherPlayerTest()
	{
		ClientSerializeTest(
			new HealOtherPlayer
			{
				OtherPlayerSlot = 6,
				Amount = 400
			}
			, new byte[] { 0x06, 0x00, 0x42, 0x06, 0x90, 0x01 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void HitSwitchTest()
	{
		ClientSerializeTest(
			new HitSwitch
			{
				Position = new(20, 40)
			}
			, new byte[] { 0x07, 0x00, 0x3B, 0x14, 0x00, 0x28, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void ItemAnimationTest()
	{
		ClientSerializeTest(
			new ItemAnimation
			{
				PlayerSlot = 60,
				Rotation = 2f,
				Animation = 20
			}
			, new byte[] { 0x0A, 0x00, 0x29, 0x3C, 0x00, 0x00, 0x00, 0x40, 0x14, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void LiquidUpdateTest()
	{
		ClientSerializeTest(
			new LiquidUpdate
			{
				Liquid = 20,
				LiquidType = 30,
				TilePosition = new(50, 60)
			}
			, new byte[] { 0x09, 0x00, 0x30, 0x32, 0x00, 0x3C, 0x00, 0x14, 0x1E }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void ManaEffectTest()
	{
		ClientSerializeTest(
			new ManaEffect
			{
				PlayerSlot = 12,
				Amount = 60
			}
			, new byte[] { 0x06, 0x00, 0x2B, 0x0C, 0x3C, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void NPCHomeTest()
	{
		ClientSerializeTest(
			new NPCHome
			{
				NPCSlot = 10,
				Position = new(100, 200),
				Homeless = 3
			}
			, new byte[] { 0x0A, 0x00, 0x3C, 0x0A, 0x00, 0x64, 0x00, 0xC8, 0x00, 0x03 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PaintTileTest()
	{
		ClientSerializeTest(
			new PaintTile
			{
				Color = 7,
				Position = new(700, 300)
			}
			, new byte[] { 0x08, 0x00, 0x3F, 0xBC, 0x02, 0x2C, 0x01, 0x07 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PaintWallTest()
	{
		ClientSerializeTest(
			new PaintWall
			{
				Color = 7,
				Position = new(700, 300)
			}
			, new byte[] { 0x08, 0x00, 0x40, 0xBC, 0x02, 0x2C, 0x01, 0x07 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlaceChestTest()
	{
		ClientSerializeTest(// TODO: add a server side serialization
			new PlaceChest
			{
				Position = new(500, 600),
				Action = 2,
				Style = 50,
				ChestIDToDestroy = 0
			}
			, new byte[] { 0x0C, 0x00, 0x22, 0x02, 0xF4, 0x01, 0x58, 0x02, 0x32, 0x00, 0x00, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerBuffsTest()
	{
		var packet = new PlayerBuffs()
		{
			PlayerSlot = 20,
		};
		packet.BuffTypes[10] = 22;
		ClientSerializeTest(packet
			, new byte[] {
				0x30, 0x00, 0x32, 0x14, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x16, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
				0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerManaTest()
	{
		ClientSerializeTest(
			new PlayerMana
			{
				PlayerSlot = 20,
				StatMana = 60,
				StatManaMax = 100
			}
			, new byte[] { 0x08, 0x00, 0x2A, 0x14, 0x3C, 0x00, 0x64, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerTeamTest()
	{
		ClientSerializeTest(
			new PlayerTeam
			{
				PlayerSlot = 14,
				Team = 2
			}
			, new byte[] { 0x05, 0x00, 0x2D, 0x0E, 0x02 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayerZoneTest()
	{
		ClientSerializeTest(
			new PlayerZone
			{
				PlayerSlot = 24,
				Zone = 6
			}
			, new byte[] { 0x08, 0x00, 0x24, 0x18, 0x06, 0x00, 0x00, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void PlayMusicItemTest()
	{
		ClientSerializeTest(
			new PlayMusicItem
			{
				PlayerSlot = 30,
				Range = 4f
			}
			, new byte[] { 0x08, 0x00, 0x3A, 0x1E, 0x00, 0x00, 0x80, 0x40 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void SpecialNPCEffectTest()
	{
		ClientSerializeTest(
			new SpecialNPCEffect
			{
				PlayerSlot = 8,
				Action = 20
			}
			, new byte[] { 0x05, 0x00, 0x33, 0x08, 0x14 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void StrikeNPCWithHeldItemTest()// TODO: complete this fact
	{
		/*ClientSerializeTest(
			new StrikeNPCWithHeldItem
			{
				PlayerSlot = 8,
				NPCSlot = 9
			}
			, new byte[] { }
		);*/
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void SyncNPCNameTest()// TODO: add a server side serialization
	{
		ClientSerializeTest(
			new SyncNPCName
			{
				NPCSlot = 50,
			}
			, new byte[] { 0x05, 0x00, 0x38, 0x32, 0x00 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void TeleportTest()// TODO: add a server side serialization
	{
		ClientSerializeTest(
			new Teleport
			{
				PlayerSlot = 60,
				Bit1 = 6,
				Style = 2,
				Position = new(500, 600),
				ExtraInfo = 50
			}
			, new byte[] { 0x0F, 0x00, 0x41, 0x06, 0x3C, 0x00, 0x00, 0x00, 0xFA, 0x43, 0x00, 0x00, 0x16, 0x44, 0x02 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void UnlockTest()// TODO: add a server side serialization
	{
		ClientSerializeTest(
			new Unlock
			{
				PlayerSlot = 20,
				Position = new(500, 600),
			}
			, new byte[] { 0x08, 0x00, 0x34, 0x14, 0xF4, 0x01, 0x58, 0x02 }
		);
	}

	[TestedFor("1.4.3.6")]
	[Fact]
	public void UpdateSignTest()// TODO: add a server side serialization
	{
		ClientSerializeTest(
			new UpdateSign
			{
				PlayerSlot = 28,
				Position = new(600, 900),
				SignFlags = 5,
				SignSlot = 7,
				Text = "123"
			}
			, new byte[] { 0x0F, 0x00, 0x2F, 0x07, 0x00, 0x58, 0x02, 0x84, 0x03, 0x03, 0x31, 0x32, 0x33, 0x1C, 0x05 }
		);
	}
}
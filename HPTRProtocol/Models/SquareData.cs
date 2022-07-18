namespace HPTRProtocol.Models;

public struct SquareData : ISerializable
{
	public short TilePosX { get; set; }
	public short TilePosY { get; set; }
	public byte Width { get; set; }
	public byte Height { get; set; }
	public TileChangeType ChangeType { get; set; }
	public SimpleTileData[,] Tiles { get; set; }

	public void Deserialize(BinaryReader br)
	{
		TilePosX = br.ReadInt16();
		TilePosY = br.ReadInt16();
		Width = br.ReadByte();
		Height = br.ReadByte();
		ChangeType = (TileChangeType)br.ReadByte();
		Tiles = new SimpleTileData[Width, Height];
		for (int i = 0; i < Width; i++)
		{
			for (int j = 0; j < Height; j++)
			{
				var tile = new SimpleTileData
				{
					Flags1 = br.ReadByte(),
					Flags2 = br.ReadByte()
				};
				if (tile.Flags2[2])
				{
					tile.TileColor = br.ReadByte();
				}
				if (tile.Flags2[3])
				{
					tile.WallColor = br.ReadByte();
				}
				if (tile.Flags1[0])
				{
					tile.TileType = br.ReadUInt16();
					if (Constants.tileFrameImportant[tile.TileType])
					{
						tile.FrameX = br.ReadInt16();
						tile.FrameY = br.ReadInt16();
					}
				}
				if (tile.Flags1[2])
				{
					tile.WallType = br.ReadUInt16();
				}
				if (tile.Flags1[3])
				{
					tile.Liquid = br.ReadByte();
					tile.LiquidType = br.ReadByte();
				}
				Tiles[i, j] = tile;
			}
		}
	}
	public void Serialize(BinaryWriter bw)
	{
		bw.Write(TilePosX);
		bw.Write(TilePosY);
		bw.Write(Width);
		bw.Write(Height);
		bw.Write((byte)ChangeType);
		for (int i = 0; i < Tiles.GetLength(0); i++)
		{
			for (int j = 0; j < Tiles.GetLength(1); j++)
			{
				var tile = Tiles[i, j];
				var flags1 = tile.Flags1;
				var flags2 = tile.Flags2;
				bw.Write(flags1);
				bw.Write(flags2);

				if (flags2[2])
				{
					bw.Write(tile.TileColor);
				}
				if (flags2[3])
				{
					bw.Write(tile.WallColor);
				}
				if (flags1[0])
				{
					bw.Write(tile.TileType);
					if (Constants.tileFrameImportant[tile.TileType])
					{
						bw.Write(tile.FrameX);
						bw.Write(tile.FrameY);
					}
				}
				if (flags1[2])
				{
					bw.Write(tile.WallType);
				}
				if (flags1[3])
				{
					bw.Write(tile.Liquid);
					bw.Write(tile.LiquidType);
				}
			}
		}
	}
}

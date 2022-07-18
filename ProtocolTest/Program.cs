using HPTRProtocol;
using HPTRProtocol.Packets.C2S;
using HPTRProtocol.Packets.S2C;
using HPTRProtocol.Packets.Sync;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace ProtocolTest;

internal class Program
{
	unsafe static void Main(string[] args)
	{
		var mgr = PacketSerializer.CreateFromDefault(true);
		using var ms = new MemoryStream();
		using var bw = new BinaryWriter(ms); 
        var b = mgr.Serialize(new ConnectRequest
        {
            Version = "Terraria248"
        });
        Console.WriteLine(string.Join(" ", b.Select(b => $"{b:x2}")));
        var p2 = mgr.Deserialize(new BinaryReader(new MemoryStream(mgr.Serialize(new TileSection
        {
            Data = new()
            {
                IsCompressed = true,
                StartX = 0,
                StartY = 0,
                Width = 10,
                Height = 10,
                Tiles = new HPTRProtocol.Models.ComplexTileData[100],
                SignCount = 1,
                Signs = new HPTRProtocol.Models.SignData[] { new() { TileX = 0, TileY = 0, ID = 0, Text = "TestSign" } },
                ChestCount = 1,
                Chests = new HPTRProtocol.Models.ChestData[] { new() { TileX = 0, TileY = 0, ID = 0, Name = "TestChest" } },
                TileEntityCount = 8,
                TileEntities = new HPTRProtocol.Models.TileEntity[]
                {
                        new HPTRProtocol.Models.TileEntities.TEDisplayDoll()
                        {
                            ID = 0,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 0, Y = 0 }
                        },
                        new HPTRProtocol.Models.TileEntities.TEFoodPlatter()
                        {
                            ID = 1,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 1, Y = 1 },
                            Item = new()
                            {
                                ItemID = 757,
                                Stack = 1
                            }
                        },
                        new HPTRProtocol.Models.TileEntities.TEHatRack()
                        {
                            ID = 2,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 2, Y = 2 },
                            Items = new HPTRProtocol.Models.ItemData[]
                            {
                                new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                },
                                new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                }
                            },
                            Dyes = new HPTRProtocol.Models.ItemData[]
                            {
                                new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                },
                                new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                }
                            }
                        },
                        new HPTRProtocol.Models.TileEntities.TEItemFrame()
                        {
                            ID = 3,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 3, Y = 3 },
                            Item = new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                }
                        },
                        new HPTRProtocol.Models.TileEntities.TELogicSensor()
                        {
                            ID = 4,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 4, Y = 4 },
                            LogicCheck = HPTRProtocol.Models.LogicCheckType.None,
                            On = true
                        },
                        new HPTRProtocol.Models.TileEntities.TETeleportationPylon()
                        {
                            ID = 5,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 5, Y = 5 },
                        },
                        new HPTRProtocol.Models.TileEntities.TETrainingDummy()
                        {
                            ID = 6,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 6, Y = 6 },
                            NPC = 1
                        },
                        new HPTRProtocol.Models.TileEntities.TEWeaponsRack()
                        {
                            ID = 7,
                            Position = new HPTRProtocol.Models.ShortPosition { X = 7, Y = 7 },
                            Item = new()
                                {
                                    ItemID = 757,
                                    Stack = 1
                                }
                        }
                }
            }
        }))));
        var sw = Stopwatch.StartNew();

        for (int i = 0; i < 1000000; ++i)
        {
            mgr.Serialize(new TileChange
            {
                Position = new HPTRProtocol.Models.ShortPosition { X = 2, Y = 4 }
            });
        }

        Console.WriteLine($"serialize cost: {sw.ElapsedMilliseconds / 1000f:f2}us");

        sw = Stopwatch.StartNew();

        var ms2 = new MemoryStream(mgr.Serialize(new TileChange
        {
            Position = new HPTRProtocol.Models.ShortPosition { X = 2, Y = 4 }
        }));
        var br = new BinaryReader(ms2);

        for (int i = 0; i < 1000000; ++i)
        {
            br.BaseStream.Position = 0;
            mgr.Deserialize(br);
        }

        Console.WriteLine($"deserialize cost: {sw.ElapsedMilliseconds / 1000f:f2}us");
    }
}
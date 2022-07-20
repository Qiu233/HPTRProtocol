global using HPTRProtocol.Models;
global using HPTRProtocol.Models.TileEntities;
global using HPTRProtocol.Helpers;
global using HPTRProtocol.Packets.C2S;
global using HPTRProtocol.Packets.S2C;
global using HPTRProtocol.Packets.Sync;

global using Position = HPTRProtocol.Models.Position<int>;
global using ShortPosition = HPTRProtocol.Models.Position<short>;
global using UShortPosition = HPTRProtocol.Models.Position<ushort>;


[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("PacketTests")]
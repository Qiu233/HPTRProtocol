using System.Text;

namespace HPTRProtocol;

public abstract class Packet : ISerializable
{
	public abstract MessageID Type { get; }

	protected abstract void SerializeOverride(BinaryWriter bw);
	protected abstract void DeserializeOverride(BinaryReader br);

	public virtual void Serialize(BinaryWriter bw) => SerializeOverride(bw);
	public virtual void Deserialize(BinaryReader br) => DeserializeOverride(br);
}

public interface IPlayerSlot
{
	byte PlayerSlot { get; set; }
}
public interface IOtherPlayerSlot
{
	byte OtherPlayerSlot { get; set; }
}
public interface IItemSlot
{
	short ItemSlot { get; set; }
}
public interface INPCSlot
{
	short NPCSlot { get; set; }
}
public interface IProjSlot
{
	short ProjSlot { get; set; }
}
public abstract class NetModulesPacket : Packet
{
	public abstract NetModuleType ModuleType { get; }
}
using System.Runtime.InteropServices;
using System.Text;

namespace HPTRProtocol.Models;

[StructLayout(LayoutKind.Sequential)]
public struct TreeTopsVariations : ISerializable
{
	public byte ForestTreeTopStyle1 { get; set; }
	public byte ForestTreeTopStyle2 { get; set; }
	public byte ForestTreeTopStyle3 { get; set; }
	public byte ForestTreeTopStyle4 { get; set; }
	public byte CorruptionTreeTopStyle { get; set; }
	public byte JungleTreeTopStyle { get; set; }
	public byte SnowTreeTopStyle { get; set; }
	public byte HallowTreeTopStyle { get; set; }
	public byte CrimsonTreeTopStyle { get; set; }
	public byte DesertTreeTopStyle { get; set; }
	public byte OceanTreeTopStyle { get; set; }
	public byte GlowingMushroomTreeTopStyle { get; set; }
	public byte UnderworldTreeTopStyle { get; set; }

	public void Serialize(BinaryWriter bw) => bw.WriteValue(this);
	public void Deserialize(BinaryReader br) => this = br.ReadValue<TreeTopsVariations>();
}
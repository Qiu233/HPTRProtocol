namespace HPTRProtocol.Packets.S2C;

public class CreateCombatText : Packet
{
    public override MessageID Type => MessageID.CombatTextInt;
    public Vector2 Position { get; set; }
    public Color Color { get; set; }
    public int Amount { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		Position = br.ReadSerializable<Vector2>();
		Color = br.ReadSerializable<Color>();
		Amount = br.ReadInt32();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.WriteSerializable(Position);
		bw.WriteSerializable(Color);
		bw.Write(Amount);
	}
}
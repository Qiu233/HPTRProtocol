namespace HPTRProtocol.Packets;

public class MenuSunMoon : Packet
{
    public override MessageID Type => MessageID.MenuSunMoon;
    public bool DayTime { get; set; }
    public int Time { get; set; }
    public short Sun { get; set; }
    public short Moon { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		DayTime = br.ReadBoolean();
		Time = br.ReadInt32();
		Sun = br.ReadInt16();
		Moon = br.ReadInt16();
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(DayTime);
		bw.Write(Time);
		bw.Write(Sun);
		bw.Write(Moon);
	}
}

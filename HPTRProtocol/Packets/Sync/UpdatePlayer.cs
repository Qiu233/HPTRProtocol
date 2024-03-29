﻿namespace HPTRProtocol.Packets.Sync;

public class UpdatePlayer : Packet, IPlayerSlot
{
	public override MessageID Type => MessageID.UpdatePlayer;
	public byte PlayerSlot { get; set; }
	public BitsByte Bit1 { get; set; }
	public BitsByte Bit2 { get; set; }
	public BitsByte Bit3 { get; set; }
	public BitsByte Bit4 { get; set; }
	public byte SelectedItem { get; set; }
	public Vector2 Position { get; set; }
	public Vector2 Velocity { get; set; }
	public Vector2 PotionOfReturnOriginalUsePosition { get; set; }
	public Vector2 PotionOfReturnHomePosition { get; set; }

	protected override void DeserializeOverride(BinaryReader br)
	{
		PlayerSlot = br.ReadByte();
		Bit1 = br.ReadByte();
		Bit2 = br.ReadByte();
		Bit3 = br.ReadByte();
		Bit4 = br.ReadByte();
		SelectedItem = br.ReadByte();
		Position = br.ReadSerializable<Vector2>();
		if (Bit2[2])
			Velocity = br.ReadSerializable<Vector2>();
		if (Bit3[6])
		{
			PotionOfReturnOriginalUsePosition = br.ReadSerializable<Vector2>();
			PotionOfReturnHomePosition = br.ReadSerializable<Vector2>();
		}
	}

	protected override void SerializeOverride(BinaryWriter bw)
	{
		bw.Write(PlayerSlot);
		bw.Write(Bit1);
		bw.Write(Bit2);
		bw.Write(Bit3);
		bw.Write(Bit4);
		bw.Write(SelectedItem);
		bw.WriteSerializable(Position);
		if (Bit2[2])
			bw.WriteSerializable(Velocity);
		if (Bit3[6])
		{
			bw.WriteSerializable(PotionOfReturnOriginalUsePosition);
			bw.WriteSerializable(PotionOfReturnHomePosition);
		}
	}
}

using Godot;
using System;

public partial class Slime : AnimatedSprite2D
{
	[Export]
	public RayCast2D rayCast2D_Left;
	[Export]
	public RayCast2D rayCast2D_Right;
	[Export]
	public short speed = 60;
	public short direction = 1;
	public override void _Process(double delta)
	{
		if (rayCast2D_Left.IsColliding())
		{
			direction = 1;
			FlipH=false;
		}
		if (rayCast2D_Right.IsColliding())
		{
			direction = -1;
			FlipH=true;
		}
		Position += new Vector2(direction * speed * (float)delta, 0);
	}
}

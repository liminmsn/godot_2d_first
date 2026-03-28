using Godot;
using System;
using System.ComponentModel;

public partial class Pelay : CharacterBody2D
{
	[Export]
	private AudioStreamPlayer2D audioStreamPlayer2D;
	[Export]
	private AnimatedSprite2D animatedSprite2D;
	public const float Speed = 130.0f;
	public const float JumpVelocity = -300.0f;

	public override void _PhysicsProcess(double delta)
	{
		if (!IsInstanceValid(animatedSprite2D))
			return;
		// ✅ 动画状态控制（重点）
		if (!IsOnFloor())
		{
			animatedSprite2D.Play("jump");
		}
		else if (Mathf.Abs(Velocity.X) > 1)
		{
			animatedSprite2D.Play("run");
		}
		else
		{
			animatedSprite2D.Play("idle");
		}


		Vector2 velocity = Velocity;
		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}
		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = JumpVelocity;
			audioStreamPlayer2D.Play();
		}
		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			animatedSprite2D.FlipH = direction.X < 0;
			velocity.X = direction.X * Speed;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}

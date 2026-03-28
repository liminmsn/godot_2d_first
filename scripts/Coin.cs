using Godot;
using System;

public partial class Coin : Area2D
{
	// public override void _Ready()
	// {
	// 	// BodyEntered += OnBodyEntered;
	// }
	[Export]
	private AudioStreamPlayer2D aounds=null;
	[Export]
	private AnimationPlayer animationPlayer=null;

	private void OnBodyEntered(Node2D body)
	{
		
		// GD.Print("Coin +1: " + body.Name);
		aounds.Play();
		aounds.Dispose();
		animationPlayer.Play("coin/destory");
	}
	async private void Destory()
	{
		// 等声音播放一点时间
		await ToSignal(GetTree().CreateTimer(0.3f), "timeout");
		QueueFree();
	}
}

using Godot;
using System;

public partial class Killzone : Area2D
{
	[Export]
	private Timer time = null;
	private void OnBodyEntered(Node2D body)
	{
		if (body.Name == "Player")
		{
			Engine.TimeScale = 0.5;
			var node = body.GetNode<CollisionShape2D>("CollisionShape2D");
			node.QueueFree();
			time.Start();
			GD.Print("死亡区域: " + body.Name);
		}
	}
	private void OnTimeout()
	{
		Engine.TimeScale = 1;
		GetTree().ReloadCurrentScene();
		GD.Print("等待结束");
	}
}

using Godot;
using System;

public partial class Transition : Control
{
	[Export] private Timer _timer;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_timer.Timeout += OnTimeout;
	}

	private void OnTimeout()
	{
		GetTree().ChangeSceneToPacked(GameManager.Instance.GetNextScene());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

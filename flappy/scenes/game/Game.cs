using Godot;
using System;

public partial class Game : Node2D
{
	[Export] private Marker2D _spawnUpper;
	[Export] private Marker2D _spawnLower;
	[Export] private Timer _spawnTimer;
	[Export] private PackedScene _pipesScene;
	
	//private bool _gameOver = false;
	
	public override void _Ready()
	{
		_spawnTimer.Timeout += OnSpawnPipes;
		SignalManager.Instance.OnPlaneDied += GameOver;
		
		//ScoreManager.ResetScore();
		CallDeferred("LateStuff");
		OnSpawnPipes();
	}

	private void LateStuff()
	{
		ScoreManager.ResetScore();
	}

	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= GameOver;
	}


	private void GameOver()
	{
		_spawnTimer.Stop();
	}

	private void OnSpawnPipes()
	{
		Pipes np = _pipesScene.Instantiate<Pipes>();
		AddChild(np);
		np.Position = new Vector2(_spawnLower.Position.X, GetSpawnY());
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsKeyPressed(Key.Escape) || Input.IsKeyPressed(Key.Q))
		{
			GameManager.LoadMain();
		}
	}
	
	
	public float GetSpawnY()
	{
		return (float) GD.RandRange(_spawnUpper.Position.Y, _spawnLower.Position.Y);
	}
	
}

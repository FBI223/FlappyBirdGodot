using Godot;
using System;

public partial class GameManager : Node
{
	public const float SCROLL_SPEED = 120.0f;
	public static GameManager Instance { get; private set; }
	
	private PackedScene _gameScene = GD.Load<PackedScene>("res://scenes/game/Game.tscn"); 
	private PackedScene _mainScene = GD.Load<PackedScene>("res://scenes/main/Main.tscn");
	private PackedScene _transitionScene = 
		GD.Load<PackedScene>("res://scenes/transition/Transition.tscn");

	private PackedScene _nextScene;

	public PackedScene GetNextScene()
	{
		return _nextScene;
	}
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
	private void LoadNextScene(PackedScene nextScene)
	{
		_nextScene = nextScene;
		GetTree().ChangeSceneToPacked(Instance._transitionScene );
	}

	
	public static void LoadMain()
	{
		//Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
		Instance.LoadNextScene(Instance._mainScene);
	}
	
	public static void LoadGame()
	{
		//Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
		Instance.LoadNextScene(Instance._gameScene);
	}
	
}

using Godot;
using System;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance { get; private set; }
	
	private uint _score = 0;
	private uint _highScore = 0;
	
	private const string HIGH_SCORE_FILE = "user://highscore_tappy_save";


	public static uint GetScore()
	{
		return Instance._score;
	}

	public static uint GetHighScore()
	{
		return Instance._highScore;
	}

	public override void _ExitTree()
	{
		SaveScoreToFile();
	}

	public static void SetScore(uint value)
	{
		Instance._score = value;
		if (Instance._score > Instance._highScore)
		{
			Instance._highScore = Instance._score;
			GD.Print("new high score : " + Instance._highScore );
		}
		SignalManager.EmitOnScored();
		GD.Print("score : " + Instance._score );
	}
	
	
	public static void ResetScore()
	{
		SetScore(0);
	}
	
	public static void IncrementScore()
	{
		SetScore(GetScore() + 1);
	}
	
	
	
	
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Instance = this;
		LoadScoreFromFile();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void LoadScoreFromFile()
	{
		using FileAccess file = FileAccess.Open(HIGH_SCORE_FILE,FileAccess.ModeFlags.Read);
		if (file != null)
		{
			_highScore = file.Get32();
		}
		
	}
	
	private void SaveScoreToFile()
	{
		using FileAccess file = FileAccess.Open(HIGH_SCORE_FILE,FileAccess.ModeFlags.Write);
		if (file != null)
		{
			file.Store32(_highScore);
		}
		
	}
	
}

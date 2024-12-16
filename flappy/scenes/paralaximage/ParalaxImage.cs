using Godot;
using System;
using System.Drawing;

public partial class ParalaxImage : Parallax2D
{
	[Export] private Texture2D _srcTexture;
	[Export] private Sprite2D _sprite;
	[Export] private float _speedScale; // 0 to 1
	
	public override void _Ready()
	{
		Autoscroll = new Vector2( - _speedScale * GameManager.SCROLL_SPEED, 0);
		float scaleFactor = GetViewportRect().Size.Y / _srcTexture.GetHeight();

		_sprite.Texture = _srcTexture;
		_sprite.Scale = new Vector2(scaleFactor, scaleFactor);
		
		RepeatSize = new Vector2(_srcTexture.GetWidth() * scaleFactor, 0);
		SignalManager.Instance.OnPlaneDied += OnPlaneDied;
	}
	
	public override void _ExitTree()
	{
		SignalManager.Instance.OnPlaneDied -= OnPlaneDied;
	}

	private void OnPlaneDied()
	{
		Vector2 positionP = Position;
		Autoscroll = Vector2.Zero;
		Position = positionP;
	}
	
}

using Godot;
using System;

public partial class Plane : CharacterBody2D
{
	private const float GRAVITY = 900.0f;
	const float POWER = -350.0f;
	[Export] private AnimationPlayer _animationPlayer;
	[Export] private AnimatedSprite2D _planeSprite;
	[Export] private AudioStreamPlayer _engineSound;
	

	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
		velocity.Y += GRAVITY * (float)delta;
		if (Input.IsActionJustPressed("fly"))
		{
			velocity.Y = POWER;
			_animationPlayer.Play("power");
		}
		
		Velocity = velocity;
		MoveAndSlide();

		if (IsOnFloor())
		{
			Die();
		}
	}

	public void Die()
	{
		SetPhysicsProcess(false);
		_planeSprite.Stop();
		SignalManager.EmitOnPlaneDied();
		_engineSound.Stop();
	}
}

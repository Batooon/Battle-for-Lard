using UnityEngine;

public class InAirState : State
{
    private readonly PlayerData _playerData;
    
    public InAirState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
    {
        _playerData = playerUtilities.PlayerData;
    }

    public override void Enter()
    {
        base.Enter();
        InputHandler.DirectionChanged += OnDirectionChanged;
    }

    public override void Exit()
    {
        base.Exit();
        InputHandler.DirectionChanged -= OnDirectionChanged;
    }

    public override void Update()
    {
        if (IsFalling())
            CalculateVerticalVelocity(_playerData.FallMultiplier);
        else if (IsLowJump())
            CalculateVerticalVelocity(_playerData.LowJumpMultiplier);
    }

    private void OnDirectionChanged(float direction)
    {
        PlayerUtilities.Movement.ChangeDirectionX(direction, _playerData.MaxSpeed);
    }
    
    private void CalculateVerticalVelocity(float multiplier)
    {
        Rigidbody.velocity += Vector2.up * (Physics2D.gravity.y * (multiplier - 1) * Time.deltaTime);
    }

    private bool IsLowJump()
    {
        return Rigidbody.velocity.y > 0 && Input.GetKey(InputKeys.Jump) == false;
    }

    private bool IsFalling() => Rigidbody.velocity.y < 0;
}
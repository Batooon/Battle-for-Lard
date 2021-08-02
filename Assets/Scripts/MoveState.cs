using UnityEngine;

public class MoveState : State
{
    private readonly PlayerData _playerData;

    public MoveState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
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

    private void OnDirectionChanged(float direction)
    {
        PlayerUtilities.Movement.ChangeDirectionX(direction, _playerData.MaxSpeed);
    }
}
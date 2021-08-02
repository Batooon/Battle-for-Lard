using System;
using UnityEngine;

public class IdleTransition : StateTransition
{
    private readonly GroundChecker _groundChecker;
    public IdleTransition(State targetState, PlayerUtilities playerUtils) : base(targetState, playerUtils)
    {
        _groundChecker = PlayerUtilities.GroundChecker;
    }

    protected override void Enable()
    {
        NeedTransit = IsIdle();
        InputHandler.NotMoving += OnNotMoving;
        _groundChecker.LandedOnGround += OnLandedOnGround;
    }

    protected override void Disable()
    {
        InputHandler.NotMoving -= OnNotMoving;
        _groundChecker.LandedOnGround -= OnLandedOnGround;
    }

    private void OnNotMoving()
    {
        NeedTransit = _groundChecker.IsOnGround;
    }

    private void OnLandedOnGround()
    {
        NeedTransit = InputHandler.IsWalkKeysPressed == false;
    }

    private bool IsIdle()
    {
        return InputHandler.IsWalkKeysPressed == false && _groundChecker.IsOnGround;
    }
}
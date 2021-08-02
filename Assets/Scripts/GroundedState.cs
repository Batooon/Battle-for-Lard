using UnityEngine;

public class GroundedState : State
{
    protected GroundedState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
    {
    }
}
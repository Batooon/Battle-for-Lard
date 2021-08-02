using UnityEngine;
using Utils;

namespace Logic.StateMachine.States
{
    public class GroundedState : State
    {
        protected GroundedState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
        {
        }
    }
}
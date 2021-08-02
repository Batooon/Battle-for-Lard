using UnityEngine;
using Utils;

namespace Logic.StateMachine.States
{
    public class LandState : GroundedState
    {
        public LandState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
        {
        }
    }
}
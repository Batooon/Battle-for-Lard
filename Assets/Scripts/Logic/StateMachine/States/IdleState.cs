using UnityEngine;
using Utils;

namespace Logic.StateMachine.States
{
    public class IdleState : State
    {
        //Запускать анимацию дыхания, например
        public IdleState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
        {
        }
    }
}
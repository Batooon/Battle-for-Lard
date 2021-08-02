using Data;
using UnityEngine;
using Utils;

namespace Logic.StateMachine.States
{
    public class JumpState : SkillState
    {
        private readonly PlayerData _playerData;

        public JumpState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
        {
            _playerData = playerUtilities.PlayerData;
        }

        public override void Enter()
        {
            base.Enter();
            Rigidbody.velocity = Vector2.up * _playerData.JumpVelocity;
            PlayerUtilities.IsAbilityDone = true;
        }

        public override void Update()
        {
            if (IsFalling())
                CalculateVerticalVelocity(_playerData.FallMultiplier);
            else if (IsLowJump())
                CalculateVerticalVelocity(_playerData.LowJumpMultiplier);
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
}
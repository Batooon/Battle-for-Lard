using Logic.StateMachine.States;
using Utils;

namespace Logic.StateMachine.Transitions
{
    public class LandTransition : StateTransition
    {
        public LandTransition(State targetState, PlayerUtilities playerUtils) : base(targetState, playerUtils)
        {
        }

        protected override void Enable()
        {
            PlayerUtilities.GroundChecker.LandedOnGround += OnLanded;
        }

        protected override void Disable()
        {
            PlayerUtilities.GroundChecker.LandedOnGround -= OnLanded;
        }

        private void OnLanded()
        {
            NeedTransit = true;
        }
    }
}
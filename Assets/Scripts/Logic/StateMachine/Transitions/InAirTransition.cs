using Logic.StateMachine.States;
using Utils;

namespace Logic.StateMachine.Transitions
{
    public class InAirTransition : StateTransition
    {
        public InAirTransition(State targetState, PlayerUtilities playerUtils) : base(targetState, playerUtils)
        {
        }

        protected override void Enable()
        {
            PlayerUtilities.AbilityDone += InAir;
        }

        protected override void Disable()
        {
            PlayerUtilities.AbilityDone -= InAir;
        }

        private void InAir()
        {
            NeedTransit = true;
        }
    }
}
using Logic.StateMachine.States;
using Utils;

namespace Logic.StateMachine.Transitions
{
    public class MoveTransition : StateTransition
    {
        public MoveTransition(State targetState, PlayerUtilities playerUtils) : base(targetState, playerUtils)
        {
        }

        protected override void Enable()
        {
            NeedTransit = InputHandler.IsWalkKeysPressed;
            InputHandler.StartMoving += OnMovementStarted;
        }

        protected override void Disable()
        {
            InputHandler.StartMoving -= OnMovementStarted;
        }
    
        private void OnMovementStarted()
        {
            NeedTransit = true;
        }
    }
}
public class JumpTransition : StateTransition
{
    public JumpTransition(State targetState, PlayerUtilities playerUtils) : base(targetState, playerUtils)
    {
    }

    protected override void Enable()
    {
        InputHandler.JumpKeyPressed += OnJumpKeyPressed;
    }

    protected override void Disable()
    {
        InputHandler.JumpKeyPressed -= OnJumpKeyPressed;
    }

    private void OnJumpKeyPressed()
    {
        NeedTransit = true;
    }
}
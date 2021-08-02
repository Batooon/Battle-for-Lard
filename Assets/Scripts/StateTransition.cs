using System;

public abstract class StateTransition
{
    public event Action<State> TransitTo;
    private readonly State _targetState;
    public State TargetState => _targetState;
    protected PlayerUtilities PlayerUtilities;

    private bool _needTransit;
    
    public bool NeedTransit
    {
        get => _needTransit;
        protected set
        {
            if (value)
                TransitTo?.Invoke(_targetState);
        }
    }

    protected StateTransition(State targetState, PlayerUtilities playerUtils)
    {
        _targetState = targetState;
        PlayerUtilities = playerUtils;
    }

    public void SetActive(bool isActive)
    {
        if (isActive)
            OnEnable();
        else
            Disable();
    }
    
    private void OnEnable()
    {
        _needTransit = false;
        Enable();
    }

    protected abstract void Enable();
    protected abstract void Disable();
}
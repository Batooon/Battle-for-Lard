using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    private bool _enabled;
    protected readonly Rigidbody2D Rigidbody;
    protected readonly Transform Transform;
    protected readonly PlayerUtilities PlayerUtilities;
    private readonly List<StateTransition> _transitions = new List<StateTransition>();

    public IEnumerable<StateTransition> Transitions => _transitions;

    protected State(PlayerUtilities playerUtilities, Rigidbody2D player)
    {
        Rigidbody = player;
        PlayerUtilities = playerUtilities;
        Transform = Rigidbody.GetComponent<Transform>();
    }

    public void AddTransition(StateTransition stateTransition)
    {
        _transitions.Add(stateTransition);
    }

    public virtual void Enter()
    {
        if (_enabled)
            return;
        ChangeComponentStates(true);
    }

    public virtual void Exit()
    {   
        if (_enabled == false)
            return;
        
        ChangeComponentStates(false);
    }

    private void ChangeComponentStates(bool active)
    {
        _enabled = active;
        foreach (var transition in _transitions)
            transition.SetActive(active);
    }

    public virtual void Update()
    {
    }
}
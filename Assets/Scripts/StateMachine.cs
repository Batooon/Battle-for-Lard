using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    private State _currentState;

    public StateMachine(State firstState)
    {
        _currentState = firstState;
        SubscribeToTransitions(_currentState.Transitions);
        _currentState.Enter();
    }

    public void Update()
    {
        _currentState.Update();
    }

    private void OnStateChanged(State nextState)
    {
        if (nextState != null)
            Transit(nextState);
    }

    private void Transit(State nextState)
    {
        Debug.Log(nextState);
        UnsubscribeOffTransitions(_currentState.Transitions);
        _currentState.Exit();

        _currentState = nextState;
        SubscribeToTransitions(_currentState.Transitions);
        
        _currentState.Enter();
    }

    private void SubscribeToTransitions(IEnumerable<StateTransition> transitions)
    {
        foreach (var transition in transitions)
        {
            transition.TransitTo += OnStateChanged;
        }
    }
    
    private void UnsubscribeOffTransitions(IEnumerable<StateTransition> transitions)
    {
        foreach (var transition in transitions)
        {
            transition.TransitTo -= OnStateChanged;
        }
    }
}
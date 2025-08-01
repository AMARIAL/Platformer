using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EnumState> : MonoBehaviour where EnumState : Enum
{
    protected Dictionary<EnumState, BaseState<EnumState>> states = new Dictionary<EnumState, BaseState<EnumState>>();
    private BaseState<EnumState> currentState;
    protected BaseState<EnumState> CurrentState {get { return currentState; } set {currentState = value;}}
    
    protected bool isTransitioning = false;
    private EnumState nextStateKey;
    
    private void Start()
    {
        CurrentState.Enter();
    }
    
    private void Update()
    {
        if(isTransitioning) return;
        
        Debug.Log(nextStateKey + " " + CurrentState.StateKey);
        if (nextStateKey.Equals(CurrentState.StateKey))
            CurrentState.Update();
        else
            TransitionToState(nextStateKey);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        CurrentState.OnTriggerEnter2D(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        CurrentState.OnTriggerExit2D(other);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        CurrentState.OnTriggerStay2D(other);
    }

    private void TransitionToState(EnumState key)
    {
        isTransitioning = true;
        CurrentState.Exit();
        CurrentState = states[key];
        CurrentState.Enter();
        nextStateKey = CurrentState.GetNextState();
        isTransitioning = false;
    }
}


using System;
using UnityEngine;

public abstract class BaseState<EnumState> where EnumState : Enum
{ 
    public BaseState(EnumState key) { StateKey = key;}
    public EnumState StateKey { get; private set; }
    public abstract void Enter();
    public abstract void Exit();
    public abstract void Update();
    public abstract EnumState GetNextState();
    public abstract void OnTriggerEnter2D(Collider2D other);
    public abstract void OnTriggerExit2D(Collider2D other);
    public abstract void OnTriggerStay2D(Collider2D other);
}

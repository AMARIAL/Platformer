using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : StateManager<Player.State>
{
    public enum State
    {
        Idle,
        Move,
        Jump,
        Attack,
        Death
    }
    public static Player ST  {get; private set;}
    public PlayerVars playerVars;
    
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    [SerializeField] private Rigidbody2D rigidBody;
    [SerializeField] private GroundDetection groundDetection;
    [SerializeField] private AnimationCurve speedCurve;
    [SerializeField] private Animator animator;
    [SerializeField] private Inputs inputs;
    [SerializeField] private Health health;

    private void Awake()
    {
        ST = this;

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        inputs = GetComponent<Inputs>();
        groundDetection = GetComponentInChildren<GroundDetection>();
        speedCurve = new AnimationCurve (new Keyframe(-1, -moveSpeed), new Keyframe(1, moveSpeed));
        playerVars = new PlayerVars(rigidBody, animator, groundDetection,inputs,health,speedCurve);
        
        InitializeStates();
    }

    private void InitializeStates()
    {
        states.Add(State.Idle, new IdleState(playerVars, State.Idle));
        states.Add(State.Jump, new JumpState(playerVars, State.Jump));
        states.Add(State.Move, new MoveState(playerVars, State.Move));
        states.Add(State.Death, new DeathState(playerVars, State.Death));
        CurrentState = states[State.Idle];
    }
    public void TransitionToState(Player.State key)
    {
        if(isTransitioning) return;
        isTransitioning = true;
        CurrentState.Exit();
        CurrentState = states[key];
        CurrentState.Enter();
        isTransitioning = false;
    }

}
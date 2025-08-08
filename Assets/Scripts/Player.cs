using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Unit
{
    public enum State
    {
        Active,
        Idle,
        Move,
        Jump,
        Fall,
        Attack,
        Death
    }
    public static Player ST  {get; private set;}

    public Dictionary<State, bool> currentStates = new Dictionary<State, bool>();
    
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
        if(ST == null) ST = this;
    }

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        inputs = GetComponent<Inputs>();
        groundDetection = GetComponentInChildren<GroundDetection>();
        speedCurve = new AnimationCurve (new Keyframe(-1, -moveSpeed), new Keyframe(1, moveSpeed));
    }

    private void Update()
    {
        ChangeStates();
        DoMechanics();
    }

    private void ChangeStates()
    {
        if (health.CurrentHealth <=0)
            currentStates.Add(State.Death, true);
        
        if (groundDetection.IsGrounded())
        {
            if(inputs.isJumpPressed)
                currentStates.Add(State.Jump, true);
            else if (currentStates.ContainsKey(State.Jump))
                currentStates.Remove(State.Jump);
            
            if (currentStates.ContainsKey(State.Fall))
                currentStates.Remove(State.Fall);
        }
        else
        {
            if(!currentStates.ContainsKey(State.Jump) && !currentStates.ContainsKey(State.Fall))
                currentStates.Add(State.Fall, true);
        }

        if(inputs.isFirePressed && !currentStates.ContainsKey(State.Attack))
            currentStates.Add(State.Attack, true);
        
        if(Mathf.Abs(inputs.horizontalDirection) > 0.01f)
            
    }

    private void DoMechanics ()
    {
        if (currentStates.ContainsKey(State.Jump))
            Jump();

        if (currentStates.ContainsKey(State.Move))
            Move();
    }

    private void Jump()
    {
        rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
    }
    private void Move()
    {
        
    }
}
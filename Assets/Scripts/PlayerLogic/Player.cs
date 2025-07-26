using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : Unit
{
    public static Player ST  {get; private set;}

    public enum State
    {
        Idle,
        Run,
        Jump,
        Attack,
        Dead
    }
    
    [SerializeField] public State state;
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rigidBody;
    private GroundDetection groundDetection;
    private AnimationCurve speedCurve;
    [HideInInspector] public Health health;

    private void Awake()
    {
        ST = this;
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = GetComponent<Health>();
        groundDetection = GetComponentInChildren<GroundDetection>();
    }

    private void Start()
    {
        speedCurve = new AnimationCurve (new Keyframe(-1, -moveSpeed), new Keyframe(1, moveSpeed));
    }

    public void Restart()
    {
        rigidBody.simulated = true;
        health.Resurrection();
        animator.Play("Idle");
    }

    public void Move(float dir, bool isJump)
    {
        animator.SetFloat("isRunning", Mathf.Abs(rigidBody.velocity.x));
        
        if(!IsAlive || !IsCanMove) return;
        
        if(isJump)
            Jump();
        
        if (animator.GetBool("isGrounded") != groundDetection.IsGrounded())
        {
            animator.SetBool("isGrounded", groundDetection.IsGrounded());
            animator.SetBool("isJumping", false);
        }
        
        if (Mathf.Abs(dir) > 0.01f)
            HorizontalMove(dir);
        
        if(IsFlip && dir > 0 || !IsFlip && dir < 0)
            Flip();
    }
    private void HorizontalMove(float dir)
    {
        rigidBody.velocity = new Vector2(speedCurve.Evaluate(dir) * moveSpeed, rigidBody.velocity.y);
    }
    private void Jump()
    {
        if(groundDetection.IsGrounded())
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        
        animator.SetBool("isJumping", true);
    }
    public override void Die()
    {
        IsAlive = false;
        rigidBody.simulated = false;
        state = State.Dead;
        animator.SetTrigger("trDeath");
        GameManager.ST.PlayerDead();
    }
}
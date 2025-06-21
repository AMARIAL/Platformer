using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [Header("Параметры")]
    [SerializeField] private float jumpForce;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isFlip;
    
    private Rigidbody2D rigidBody;
    private GroundDetection groundDetection;
    private AnimationCurve speedCurve;
    private Animator animator;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        groundDetection = GetComponentInChildren<GroundDetection>();
    }

    private void Start()
    {
        speedCurve = new AnimationCurve (new Keyframe(-1, -moveSpeed), new Keyframe(1, moveSpeed));
        isFlip = false;
    }

    public void Flip()
    {
        isFlip = !isFlip;
        transform.localScale = new Vector3(isFlip ? -1 : 1, 1, 1);
    }

    public void Move(float dir, bool isJump)
    {
        if(isJump)
            Jump();
        
        if (animator.GetBool("isGrounded") != groundDetection.isGrounded)
        {
            animator.SetBool("isGrounded", groundDetection.isGrounded);
            animator.SetBool("isJumping", false);
        }
        
        if (Mathf.Abs(dir) > 0.01f)
            HorizontalMove(dir);
        
        if(isFlip && dir > 0 || !isFlip && dir < 0)
            Flip();
    }
    private void HorizontalMove(float dir)
    {
        rigidBody.velocity = new Vector2(speedCurve.Evaluate(dir) * moveSpeed, rigidBody.velocity.y);
       
        animator.SetFloat("isRunning", Mathf.Abs(rigidBody.velocity.x));
    }
    private void Jump()
    {
        if(groundDetection.isGrounded)
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
        
        animator.SetBool("isJumping", true);
    }
}}
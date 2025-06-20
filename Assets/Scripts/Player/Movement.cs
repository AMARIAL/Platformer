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

    private Rigidbody2D rb;
    private GroundDetection gd;
    private AnimationCurve speedCurve;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
    }

    private void Start()
    {
        speedCurve = new AnimationCurve (new Keyframe(-1, -moveSpeed), new Keyframe(1, moveSpeed));
    }

    public void Move(float dir, bool isJump)
    {
        if(isJump)
            Jump();
        if (Mathf.Abs(dir) > 0.01f)
            HorizontalMove(dir);
    }
    private void HorizontalMove(float dir)
    {
        rb.velocity = new Vector2(speedCurve.Evaluate(dir) * moveSpeed, rb.velocity.y);
    }
    private void Jump()
    {
        if(gd.isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}}
using System;
using UnityEngine;
namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb;
    private GroundDetection gd;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        gd = GetComponentInChildren<GroundDetection>();
    }

    public void Move(float dir, bool isJump)
    {
        if(isJump)
            Jump();
    }

    private void Jump()
    {
        if(gd.isGrounded)
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}}
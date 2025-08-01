using UnityEngine;

public class JumpState : PlayerState
{
    private float jumpForce = 3;
    
    public JumpState(PlayerVars playerVars, Player.State key) : base(playerVars, key)
    {
        PlayerVars PlayerVars = playerVars;
    }

    public override void Enter()
    {
        PlayerVars.Rigidbody2D.velocity = new Vector2(PlayerVars.Rigidbody2D.velocity.x, jumpForce);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        
    }

    public override Player.State GetNextState()
    {
        return StateKey; 
    }

    public override void OnTriggerEnter2D(Collider2D other)
    {
    }

    public override void OnTriggerExit2D(Collider2D other)
    {
    }

    public override void OnTriggerStay2D(Collider2D other)
    {
    }
}
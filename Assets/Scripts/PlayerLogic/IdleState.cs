using UnityEngine;
public class IdleState : PlayerState
{
    public IdleState(PlayerVars playerVars, Player.State key) : base(playerVars, key)
    {
        PlayerVars PlayerVars = playerVars;
    }

    public override void Enter()
    {
        PlayerVars.Animator.SetBool("isGrounded",true);
    }

    public override void Exit()
    {
    }

    public override void Update()
    {
        if(PlayerVars.Inputs.isJumpPressed && PlayerVars.GroundDetection.IsGrounded())
            Player.ST.TransitionToState(Player.State.Jump);
        
                //if(PlayerVars.Inputs.horizontalDirection > 0)
            //PlayerVars.Rigidbody2D.velocity = new Vector2(speedCurve.Evaluate(dir) * moveSpeed, PlayerVars.Rigidbody2D.velocity.y);
            
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

using UnityEngine;
public class DeathState : PlayerState
{
    public DeathState(PlayerVars playerVars, Player.State key) : base(playerVars, key)
    {
        PlayerVars PlayerVars = playerVars;
    }

    public override void Enter()
    {
        PlayerVars.Animator.SetTrigger("trDeath");
    }

    public override void Exit()
    {
    }

    public override void Update()
    {

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

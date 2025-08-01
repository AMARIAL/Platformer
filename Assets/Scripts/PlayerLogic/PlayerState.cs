using UnityEngine;

public abstract class PlayerState : BaseState<Player.State>
{
    protected PlayerVars PlayerVars;
    protected PlayerState(PlayerVars playerVars, Player.State key) : base(key)
    {
        PlayerVars = playerVars;
    }
    
}

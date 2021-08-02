using UnityEngine;

public class SkillState : State
{   
    public SkillState(PlayerUtilities playerUtilities, Rigidbody2D player) : base(playerUtilities, player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        PlayerUtilities.IsAbilityDone = false;
    }
}
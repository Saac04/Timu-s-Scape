using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitPlatform : PlayerState
{
    public PlayerExitPlatform(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter() {
        base.Enter();
        Debug.Log("Modo salida");
    }

    public override void Update()
    {
        base.Update();
        
        Vector3 lastHorizontalVelocity = player.MoveState.GetLastHorizontalVelocity();
        player.PlayerController.rb.velocity = new Vector3(lastHorizontalVelocity.x, player.PlayerController.rb.velocity.y, 0f);
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Caida");
    }

    public override void Update() {
        base.Update();


        if (player.PlayerController.IsOnGround()) {
            playerStateMachine.ChangeState(player.IdleState);
        }

    }
}

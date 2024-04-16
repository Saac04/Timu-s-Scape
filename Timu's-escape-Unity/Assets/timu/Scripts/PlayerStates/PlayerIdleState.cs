using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{


    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Idle");
        player.jumpForce = 5f;
    }

    public override void Update()
    {
        base.Update();

        if (player.PlayerController.horizontalInput != 0f)
        {
            playerStateMachine.ChangeState(player.MoveState);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
}

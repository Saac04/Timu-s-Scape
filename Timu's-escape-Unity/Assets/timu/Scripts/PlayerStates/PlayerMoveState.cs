using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 movimiento = new Vector3(player.PlayerController.horizontalInput, 0f, 0f) * player.playerData.moveSpeed * Time.fixedDeltaTime;

        player.PlayerController.rb.MovePosition(player.PlayerController.rb.position + movimiento);

        if (player.PlayerController.horizontalInput == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (!player.PlayerController.IsOnGround()) 
        {
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
}

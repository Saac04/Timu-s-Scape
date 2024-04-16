using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private Vector3 lastHorizontalVelocity;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Move");
    }

    public override void Update()
    {
        base.Update();

        Vector3 movimiento = new Vector3(player.PlayerController.horizontalInput, 0f, 0f) * player.PlayerController.moveSpeed * Time.deltaTime;


        player.PlayerController.rb.MovePosition(player.PlayerController.rb.position + movimiento);


        if (player.PlayerController.horizontalInput == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
        if (!player.PlayerController.IsOnGround()) {
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }

}
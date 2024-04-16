using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private Rigidbody rb;
    private PlayerController playerController;


    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        rb = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Idle");
    }

    public override void Update()
    {
        base.Update();

        if (playerController.horizontalInput != 0f)
        {
            playerStateMachine.ChangeState(player.MoveState);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
}

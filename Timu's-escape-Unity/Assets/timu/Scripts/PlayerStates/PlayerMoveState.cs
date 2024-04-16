using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private Rigidbody rb;
    private PlayerController playerController;

    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        playerController = player.GetComponent<PlayerController>();
        rb = player.GetComponent<Rigidbody>();
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Move");
    }

    public override void Update()
    {
        base.Update();
        player.ApplyGravity();


        Vector3 movimiento = new Vector3(playerController.horizontalInput, 0f, 0f) * playerController.moveSpeed * Time.deltaTime;

        rb.MovePosition(rb.position + movimiento);

        // Si no hay entrada horizontal, transicionar al estado de reposo
        if (playerController.horizontalInput == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
}

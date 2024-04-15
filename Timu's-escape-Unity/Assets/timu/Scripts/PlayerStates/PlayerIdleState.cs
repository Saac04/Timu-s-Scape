using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    private PlayerController playerController;

    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
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

        player.Gravity();
        
        // Obtener la entrada horizontal del jugador desde PlayerController
        float horizontalInput = playerController.horizontalInput;

        // Si se detecta movimiento horizontal, transicionar al estado de movimiento
        if (horizontalInput != 0f)
        {
            playerStateMachine.ChangeState(player.MoveState);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}



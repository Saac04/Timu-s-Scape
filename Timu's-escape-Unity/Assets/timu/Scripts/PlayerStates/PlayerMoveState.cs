using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    private PlayerController playerController;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        playerController = player.GetComponent<PlayerController>();

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log ("Modo Move");
    }

    public override void Update() {
        
        base.Update();
        
        // Obtener la entrada horizontal del jugador desde PlayerController
        float horizontalInput = playerController.horizontalInput;

        // Si se detecta movimiento horizontal, transicionar al estado de movimiento
        if (horizontalInput == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
}

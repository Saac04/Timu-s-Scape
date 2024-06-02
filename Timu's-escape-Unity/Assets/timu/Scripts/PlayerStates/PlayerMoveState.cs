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

        // Calcular el movimiento usando Time.fixedDeltaTime
        Vector3 movimiento = new Vector3(player.PlayerController.horizontalInput, 0f, 0f) * player.playerData.moveSpeed * Time.fixedDeltaTime;

        // Mover el Rigidbody a la nueva posición
        player.PlayerController.rb.MovePosition(player.PlayerController.rb.position + movimiento);

        // Cambiar de estado si el input horizontal es cero
        if (player.PlayerController.horizontalInput == 0f)
        {
            playerStateMachine.ChangeState(player.IdleState);
        }

        // Cambiar de estado si el jugador no está en el suelo
        if (!player.PlayerController.IsOnGround()) 
        {
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }

        // Cambiar de estado si se presiona la tecla de salto (espacio)
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
}

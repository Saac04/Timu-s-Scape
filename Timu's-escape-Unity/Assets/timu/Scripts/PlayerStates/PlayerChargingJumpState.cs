using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingJumpState : PlayerState
{
    private float timeElapsed;

    public PlayerChargingJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        timeElapsed = 0f;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        // Incrementa el tiempo transcurrido con el deltaTime de FixedUpdate
        timeElapsed += Time.fixedDeltaTime;

        // Calcula el porcentaje de tiempo transcurrido en relación al maxJumpTimer
        float timePercentage = Mathf.Clamp01(timeElapsed / player.playerData.maxJumpTimer);

        // Interpola la fuerza de salto en función del porcentaje de tiempo transcurrido
        float interpolatedJumpForce = Mathf.Lerp(player.playerData.minJumpForce, player.playerData.maxJumpForce, timePercentage);

        // Actualiza la fuerza de salto en los datos del jugador
        player.playerData.jumpForce = interpolatedJumpForce;

        // Si el input vertical es 0 (se ha soltado el botón de salto)
        if (player.PlayerController.verticalInput == 0f)
        {
            // Incrementa el conteo total de saltos
            player.playerData.totalJumps++;

            // Guarda la dirección horizontal actual
            player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;

            // Cambia al estado de salto
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}

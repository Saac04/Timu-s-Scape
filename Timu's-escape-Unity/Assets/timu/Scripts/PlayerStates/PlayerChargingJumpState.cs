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
        Debug.Log("Modo Charging Jump");
        timeElapsed = 0f;
    }

    public override void Update()
    {
        base.Update();

        timeElapsed += Time.deltaTime;

        // Calcula el porcentaje de tiempo transcurrido
        float timePercentage = Mathf.Clamp01(timeElapsed / player.playerData.maxJumpTimer);

        // Calcula la fuerza de salto interpolada entre el mínimo y el máximo
        float interpolatedJumpForce = Mathf.Lerp(player.playerData.minJumpForce, player.playerData.maxJumpForce, timePercentage);

        // Establece la fuerza de salto actual
        player.playerData.jumpForce = interpolatedJumpForce;

        // Verifica si se ha soltado la tecla de salto
        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Incrementa el contador de saltos
            player.playerData.totalJumps++;

            // Registra la dirección horizontal
            player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;

            // Cambia al estado de salto
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}

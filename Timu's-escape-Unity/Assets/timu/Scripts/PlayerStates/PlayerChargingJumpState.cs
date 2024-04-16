using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingJumpState : PlayerState
{
    private float maxJumpForce = 10f; // Máximo valor de carga del salto
    private float chargeRate; // Tasa de carga

    public PlayerChargingJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
         // Calcular la tasa de carga para alcanzar el máximo en 2 segundos
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Charging Jump");
        chargeRate = maxJumpForce / 2f;
    }

    public override void Update()
    {
        base.Update();

        player.jumpForce += chargeRate * Time.deltaTime;

        player.jumpForce = Mathf.Clamp(player.jumpForce, 0f, maxJumpForce);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}

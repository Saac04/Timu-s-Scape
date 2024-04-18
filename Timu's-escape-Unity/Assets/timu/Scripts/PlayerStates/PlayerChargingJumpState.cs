using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingJumpState : PlayerState
{
    private float chargeRate;

    public PlayerChargingJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Charging Jump");
        chargeRate = player.playerData.maxJumpForce / 2f;
    }

    public override void Update()
    {
        base.Update();

        player.playerData.jumpForce += chargeRate * Time.deltaTime;

        player.playerData.jumpForce = Mathf.Clamp(player.playerData.jumpForce, 0f, player.playerData.maxJumpForce);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            player.playerData.totalJumps++;
            player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;
            playerStateMachine.ChangeState(player.JumpState);

        }
    }
}

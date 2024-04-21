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

    public override void Update()
    {
        base.Update();

        timeElapsed += Time.deltaTime;

        float timePercentage = Mathf.Clamp01(timeElapsed / player.playerData.maxJumpTimer);

        float interpolatedJumpForce = Mathf.Lerp(player.playerData.minJumpForce, player.playerData.maxJumpForce, timePercentage);

        player.playerData.jumpForce = interpolatedJumpForce;

        if (player.PlayerController.verticalInput == 0f)
        {
            player.playerData.totalJumps++;

            player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;

            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}

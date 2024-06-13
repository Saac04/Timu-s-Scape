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
        player.audioControllerTimu.PlayOneShot(player.timuAudio_CargaSalto);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();

        timeElapsed += Time.fixedDeltaTime;

        float timePercentage = Mathf.Clamp01(timeElapsed / player.playerData.maxJumpTimer);

        float interpolatedJumpForce = Mathf.Lerp(player.playerData.minJumpForce, player.playerData.maxJumpForce, timePercentage);

        float interpolatedChargingScale = Mathf.Lerp(1f, 0.45f, timePercentage);
        Vector3 scalebase = Vector3.one;
        scalebase.y = interpolatedChargingScale;
        player.timuTransform.localScale = scalebase;

        if (player.PlayerController.horizontalInput == 1)
        {
            player.timuTransform.rotation = Quaternion.Euler(player.timuTransform.eulerAngles.x, 150f, player.timuTransform.eulerAngles.z);
        }
        else if (player.PlayerController.horizontalInput == -1)
        {
            player.timuTransform.rotation = Quaternion.Euler(player.timuTransform.eulerAngles.x, 210f, player.timuTransform.eulerAngles.z);
        }

        player.playerData.jumpForce = interpolatedJumpForce;

        if (player.PlayerController.verticalInput == 0f)
        {
            player.playerData.totalJumps++;

            player.timuTransform.localScale = Vector3.one;

            player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;

            playerStateMachine.ChangeState(player.JumpState);

        }
    }
}

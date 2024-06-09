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
        player.audioControllerTimu.PlayOneShot(player.timuAudio_Mueve);
    }

    public override void Update()
    {
        base.Update();

        if (player.PlayerController.horizontalInput == 0f)
        {
            player.audioControllerTimu.Stop();
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            player.audioControllerTimu.Stop();
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
    public override void FixedUpdate()
    {
        base.FixedUpdate();

        Vector3 movimiento = new Vector3(player.PlayerController.horizontalInput, 0f, 0f) * player.playerData.moveSpeed * Time.fixedDeltaTime;

        player.PlayerController.rb.MovePosition(player.PlayerController.rb.position + movimiento);

        if (!player.PlayerController.IsOnGround()) 
        {
            player.audioControllerTimu.Stop();
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }
    }
}

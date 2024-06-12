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
        player.audioControllerTimu.Play();
        if (player.PlayerController.horizontalInput==1){ //derecha
            player.timuAnimator.SetBool("prueba 2", true);
        } else if(player.PlayerController.horizontalInput==-1){ //izq
            //player.timuAnimator.SetBool("caminar_der", true);
        }
    }

    public override void Update()
    {
        base.Update();

        if (player.PlayerController.horizontalInput == 0f)
        {
            player.audioControllerTimu.Stop();
            player.timuAnimator.SetBool("caminar_der", false);
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            player.audioControllerTimu.Stop();

            player.timuAnimator.SetBool("caminar_der", false);
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

            player.timuAnimator.SetBool("caminar_der", false);
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }
    }
}

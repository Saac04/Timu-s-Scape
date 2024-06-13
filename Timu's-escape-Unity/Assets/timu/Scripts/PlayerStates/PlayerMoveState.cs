using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    private float contador;
    public override void Enter()
    {
        base.Enter();
        player.audioControllerTimu.Play();
        contador=0;
    }

    public override void Update()
    {
        base.Update();

        if (player.PlayerController.horizontalInput == 0f)
        {
            player.timuTransform.localScale = Vector3.one;
            player.audioControllerTimu.Stop();
            player.timuAnimator.SetBool("caminar_der", false);
            playerStateMachine.ChangeState(player.IdleState);
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            player.timuTransform.localScale = Vector3.one;
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

        contador = contador + (15f / 100);
        float scaleY = (float)(0.125f * Mathf.Sin(contador) + 0.875f);
        if (contador > 6.28f)
        {
            contador = 0;
        }
        Vector3 scalebase = Vector3.one;
        scalebase.y = scaleY;
        player.timuTransform.localScale = scalebase;

        if (player.PlayerController.horizontalInput == 1)
        {
            player.timuTransform.rotation = Quaternion.Euler(player.timuTransform.eulerAngles.x, 150f, player.timuTransform.eulerAngles.z);
        }
        else if (player.PlayerController.horizontalInput == -1)
        {
            player.timuTransform.rotation = Quaternion.Euler(player.timuTransform.eulerAngles.x, 210f, player.timuTransform.eulerAngles.z);
        }

        if (!player.PlayerController.IsOnGround()) 
        {
            player.timuTransform.localScale = Vector3.one;
            player.audioControllerTimu.Stop();

            player.timuAnimator.SetBool("caminar_der", false);
            playerStateMachine.ChangeState(player.ExitPlatformState);
        }
    }
}

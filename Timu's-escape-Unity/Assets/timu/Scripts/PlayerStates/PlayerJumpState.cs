using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpState : PlayerState
{
    private bool hasAppliedJumpForce = false;
    
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        hasAppliedJumpForce = false;
        ApplyJumpForce();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if ( !player.PlayerController.IsOnGround())
        {
            playerStateMachine.ChangeState(player.FallingState);
        }
    }
    
    private void ApplyJumpForce()
    {
        if (!hasAppliedJumpForce)
        {
            //los tres primeros audios tienen un 30% y el ultimo un 10%
            float randNum = UnityEngine.Random.Range(1, 10); //10 es la suma de todos los pesos ([3,3,3,1])
            int audioNum = (int) Math.Floor((float)(randNum / 3));
            player.audioControllerTimu.PlayOneShot(player.timuAudioList_Salta[audioNum]);

            player.PlayerController.rb.AddForce((Vector3.up * player.playerData.jumpForce) + (Vector3.right * player.playerData.jumpSpeedHorizontal * player.playerData.direcctionHorizontal), ForceMode.Impulse);
            hasAppliedJumpForce = true;
        }
    }

}

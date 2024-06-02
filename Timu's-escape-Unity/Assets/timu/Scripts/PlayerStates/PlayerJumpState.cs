using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerJumpState : PlayerState
{
    private float startHeight;
    private bool hasAppliedJumpForce = false;

    
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        hasAppliedJumpForce = false;
        startHeight = player.transform.position.y; // Guarda la altura inicial del salto
        ApplyJumpForce();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        // Comprueba si la altura actual es igual o mayor que la altura inicial más la fuerza mínima de salto
        if (player.transform.position.y > startHeight )
        {

            playerStateMachine.ChangeState(player.FallingState); // Cambia al estado de caída
        }
    }
    
    private void ApplyJumpForce()
    {
        if (!hasAppliedJumpForce)
        {
            player.PlayerController.rb.AddForce((Vector3.up * player.playerData.jumpForce*Time.deltaTime) + (Vector3.right * player.playerData.jumpSpeedHorizontal * player.playerData.direcctionHorizontal*Time.deltaTime), ForceMode.Impulse);
            hasAppliedJumpForce = true;
        }
    }

}

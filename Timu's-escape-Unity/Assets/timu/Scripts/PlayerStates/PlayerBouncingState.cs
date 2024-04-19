using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBouncingState : PlayerState
{
    private Vector3 bounceSpeed;
    
    public PlayerBouncingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        bounceSpeed = player.playerData.lastVelocity;
        ReflectVelocity();
        playerStateMachine.ChangeState(player.FallingState);
    }

    private void ReflectVelocity()
    {
        // Calcular la velocidad opuesta
        Vector3 oppositeVelocity = -bounceSpeed;

        // Aplicar la velocidad opuesta al Rigidbody
        player.PlayerController.rb.velocity = oppositeVelocity;
    }
}

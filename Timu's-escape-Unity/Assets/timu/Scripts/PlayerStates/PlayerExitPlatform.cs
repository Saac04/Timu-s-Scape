using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitPlatform : PlayerState
{
    private float maxFallSpeed = -15f;

    public PlayerExitPlatform(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) {

    }

    public override void Enter()
    {
        base.Enter();
        player.playerData.direcctionHorizontal = player.PlayerController.horizontalInput;
    }

    public override void Update()
    {
        
        base.Update();
        
        player.playerData.lastVelocity = player.PlayerController.rb.velocity;

        player.PlayerController.rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;

        player.PlayerController.rb.velocity = new Vector3(player.PlayerController.rb.velocity.x, Mathf.Max(player.PlayerController.rb.velocity.y, maxFallSpeed), 0f);

        player.PlayerController.rb.velocity = new Vector3(player.playerData.moveSpeed * player.playerData.direcctionHorizontal, player.PlayerController.rb.velocity.y, 0f);

        if (player.PlayerController.IsOnGround())
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Obstacle")) {
            playerStateMachine.ChangeState(player.BouncingState);
        }
    }
}

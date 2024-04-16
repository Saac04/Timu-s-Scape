using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExitPlatform : PlayerState
{
    private float direcctionHorizontal;
    private float maxFallSpeed = -15f;

    public PlayerExitPlatform(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo salida");
        direcctionHorizontal = player.PlayerController.horizontalInput;
    }

    public override void Update()
    {
        base.Update();

        Rigidbody rb = player.PlayerController.rb;

        rb.velocity += Vector3.up * Physics.gravity.y * Time.deltaTime;

        rb.velocity = new Vector3(rb.velocity.x, Mathf.Max(rb.velocity.y, maxFallSpeed), 0f);

        rb.velocity = new Vector3(player.moveSpeed * direcctionHorizontal, rb.velocity.y, 0f);

        if (player.PlayerController.IsOnGround())
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }
}

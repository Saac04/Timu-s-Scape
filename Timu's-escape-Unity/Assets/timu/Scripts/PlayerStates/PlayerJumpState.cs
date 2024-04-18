using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    
    private float minJumpForce = 1f;
    private float height;
    private bool hasAppliedJumpForce = false;

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();    
        hasAppliedJumpForce = false;    
        height = player.transform.position.y + minJumpForce;
        Debug.Log("Modo Jump");
        ApplyJumpForce();
    }

    public override void Update()
    {
        base.Update();
        if (player.transform.position.y >= height)
        playerStateMachine.ChangeState(player.FallingState);

    }

    private void ApplyJumpForce()
    {
        if (!hasAppliedJumpForce)
        {
            player.PlayerController.rb.AddForce((Vector3.up * player.playerData.jumpForce) + (Vector3.right * player.playerData.moveSpeed * player.playerData.direcctionHorizontal), ForceMode.Impulse);
            hasAppliedJumpForce = true;
        }
    }

}

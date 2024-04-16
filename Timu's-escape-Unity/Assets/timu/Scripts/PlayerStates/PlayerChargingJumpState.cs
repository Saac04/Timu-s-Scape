using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChargingJumpState : PlayerState
{
    private Rigidbody rb;
    private PlayerController playerController;
    private PlayerJumpState jumpState;
    public PlayerChargingJumpState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        playerController = player.GetComponent<PlayerController>();
        jumpState = player.JumpState;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Carga");
    }

    public override void Update() {
        base.Update();
        
        if (Input.GetKeyUp(KeyCode.Space))
        {
            playerStateMachine.ChangeState(player.JumpState);
        }
    }
}

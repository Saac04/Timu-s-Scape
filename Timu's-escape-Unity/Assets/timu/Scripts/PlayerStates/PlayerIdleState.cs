using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{


    public PlayerIdleState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Update()
    {
        base.Update();

        
        if (player.PlayerController.horizontalInput == 1){ //derecha
            playerStateMachine.ChangeState(player.MoveState);
        }
        else if (player.PlayerController.horizontalInput == -1){ //izq
            playerStateMachine.ChangeState(player.MoveState);
        }
        /*
        if (player.PlayerController.horizontalInput != 0f)
        {
            playerStateMachine.ChangeState(player.MoveState);
        }*/
        if (player.PlayerController.verticalInput != 0f)
        {
            playerStateMachine.ChangeState(player.ChargeJumpState);
        }
    }
}

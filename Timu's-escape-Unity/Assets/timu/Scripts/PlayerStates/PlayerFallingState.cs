using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    private Rigidbody rb;
    private PlayerController playerController;
    public PlayerFallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
        rb = player.GetComponent<Rigidbody>();
        playerController = player.GetComponent<PlayerController>();

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Caida");
    }

}

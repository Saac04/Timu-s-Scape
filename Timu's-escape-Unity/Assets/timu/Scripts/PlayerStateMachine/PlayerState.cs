using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine playerStateMachine;
    protected float startTime;

    protected bool isExitingState;


    public PlayerState(Player player, PlayerStateMachine stateMachine)
    {
        this.player = player;
        this.playerStateMachine = stateMachine;
    }

    public virtual void Enter() {
        DoChecks();
        startTime = Time.time;
        isExitingState = false;
    }

    public virtual void Exit() {
        isExitingState = true;
    }

    public virtual void Update() {

    }

    public virtual void FixedUpdate() {
        DoChecks();
    }

    public virtual void DoChecks() {
        
    }

    }

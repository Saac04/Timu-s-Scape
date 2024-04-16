using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{
    public float gravity = -5f;
    public float moveSpeed = 5f;
    public float jumpForce = 5f;

    private Rigidbody rb;
    private PlayerStateMachine StateMachine;

    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerJumpState JumpState;
    public PlayerChargingJumpState ChargeJumpState;
    public PlayerFallingState FallingState;
    public PlayerExitPlatform ExitPlatform;
    public PlayerController PlayerController { get; private set; }

    private void Awake()
    {
        PlayerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody>();
        StateMachine = new PlayerStateMachine();


        IdleState = new PlayerIdleState(this, StateMachine);
        MoveState = new PlayerMoveState(this, StateMachine);
        JumpState = new PlayerJumpState(this, StateMachine, rb);
        FallingState = new PlayerFallingState(this, StateMachine);
        ChargeJumpState = new PlayerChargingJumpState(this, StateMachine);
        ExitPlatform = new PlayerExitPlatform(this, StateMachine);
        
    }

    private void Start()
    {
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }

    public void ApplyGravity()
    {
        Vector3 gravityVector = new Vector3(0f, gravity, 0f);
        rb.AddForce(gravityVector, ForceMode.Acceleration);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (PlayerController) )]
public class Player : MonoBehaviour
{

    public float gravity = -9.8f;
    Vector3 velocity;
    CharacterController characterController;

    public PlayerStateMachine StateMachine { get; private set; }


    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerJumpState JumpState;

    private void Awake() {
        
        characterController = GetComponent<CharacterController>();
        StateMachine = new PlayerStateMachine();

        IdleState = new PlayerIdleState(this, StateMachine);
        MoveState = new PlayerMoveState(this, StateMachine);
        JumpState = new PlayerJumpState(this, StateMachine, characterController);


    }

    private void Start() {
        StateMachine.Initialize(IdleState);
    }

    private void Update() {
        StateMachine.CurrentState.Update();
        Gravity();
    }

    private void FixedUpdate() {
        
        StateMachine.CurrentState.FixedUpdate();
    }

    public void Gravity() {
        

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }

}

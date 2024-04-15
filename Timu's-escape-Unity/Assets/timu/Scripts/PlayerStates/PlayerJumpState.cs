using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerJumpState : PlayerState
{
    private float jumpSpeed = 2f; // Reducimos la velocidad de salto
    private float verticalVelocity;
    private CharacterController characterController; // Referencia al CharacterController

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, CharacterController controller) : base(player, stateMachine)
    {
        characterController = controller; // Asignar la referencia recibida al characterController local
    }

    public override void Enter()
    {
        base.Enter();
        verticalVelocity = jumpSpeed;
        Debug.Log ("Modo Jump");
    }

    public override void Update()
    {
        base.Update();

        verticalVelocity += player.gravity * Time.deltaTime;

        characterController.Move(Vector3.up * verticalVelocity);

        if (characterController.isGrounded)
        {
            player.StateMachine.ChangeState(player.IdleState);
        }
        
    }

}

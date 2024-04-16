using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerState
{
    private float jumpForce = 10f; // Fuerza de salto
    private Rigidbody rb; // Referencia al Rigidbody
    private PlayerController playerController; // Referencia al PlayerController
    private bool hasAppliedJumpForce = false; // Variable para rastrear si se ha aplicado la fuerza de salto

    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, Rigidbody controller) : base(player, stateMachine)
    {
        rb = controller; // Asignar la referencia recibida al Rigidbody local
        playerController = player.GetComponent<PlayerController>(); // Obtener referencia al PlayerController
    }

    public override void Enter()
    {
        base.Enter();    
        hasAppliedJumpForce = false;    
        Debug.Log("Modo Jump");
        ApplyJumpForce();
    }

    public override void Update()
    {
        base.Update();


        if (IsFalling() && playerController.IsOnGround())
        {
            playerStateMachine.ChangeState(player.IdleState);
        }
    }

    private void ApplyJumpForce()
    {
        if (!hasAppliedJumpForce)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            hasAppliedJumpForce = true;
        }
    }

    private bool IsFalling()
{
    return hasAppliedJumpForce && rb.velocity.y < 0;
}

}

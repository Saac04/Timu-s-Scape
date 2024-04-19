using UnityEngine;

public class PlayerFallingState : PlayerState
{
    private float stateChangeTimer = 0f;
    private float stateChangeDelay = 0.5f;

    public PlayerFallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Modo Caida");

        stateChangeTimer = 0f;
    }

    public override void Update()
    {
        base.Update();

        if (player.PlayerController.IsOnGround()) {
            
            player.playerData.jumpForce = 0;

            stateChangeTimer += Time.deltaTime;

            player.PlayerController.rb.velocity = Vector3.zero;

            if (stateChangeTimer >= stateChangeDelay )
            {
                Debug.Log("Pausa");
                playerStateMachine.ChangeState(player.IdleState);
            }
        }
      }
}

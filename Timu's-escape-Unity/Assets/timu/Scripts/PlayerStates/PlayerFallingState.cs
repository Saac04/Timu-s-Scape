using UnityEngine;

public class PlayerFallingState : PlayerState
{
    private float stateChangeTimer = 0f;
    private float stateChangeDelay = 0.5f;

    private bool alreadySounded;

    public PlayerFallingState(Player player, PlayerStateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateChangeTimer = 0f;
        alreadySounded = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
        if (player.PlayerController.IsOnGround()) {
            
            if (!alreadySounded) {
                player.audioControllerTimu.PlayOneShot(player.timuAudio_CaeSuelo);
                alreadySounded = true;
            }

            player.playerData.jumpForce = 0;

            stateChangeTimer += Time.fixedDeltaTime;

            player.PlayerController.rb.velocity = Vector3.zero;

            if (stateChangeTimer >= stateChangeDelay )
            {
                alreadySounded=false;
                playerStateMachine.ChangeState(player.IdleState);
            }
        }
    }
}

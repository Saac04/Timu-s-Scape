
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public PlayerData playerData;
    private PlayerStateMachine StateMachine;
    public PlayerIdleState IdleState;
    public PlayerMoveState MoveState;
    public PlayerJumpState JumpState;
    public PlayerChargingJumpState ChargeJumpState;
    public PlayerFallingState FallingState;
    public PlayerExitPlatform ExitPlatformState;
    public PlayerController PlayerController { get; private set; }

    private Light playerLight;
    public float intensity = 0.5f;


    private void Awake()
    {    
        StateMachine = new PlayerStateMachine();
        PlayerController = GetComponent<PlayerController>();

        Physics.gravity = new Vector3(0, playerData.customGravity, 0);


        IdleState = new PlayerIdleState(this, StateMachine);
        MoveState = new PlayerMoveState(this, StateMachine);
        JumpState = new PlayerJumpState(this, StateMachine);
        FallingState = new PlayerFallingState(this, StateMachine);
        ChargeJumpState = new PlayerChargingJumpState(this, StateMachine);
        ExitPlatformState = new PlayerExitPlatform(this, StateMachine);        
    }

    private void Start()
    {
        timeR.instanciar.iniciarTiempo();
        StateMachine.Initialize(IdleState);
        playerLight = GetComponent<Light>();
        playerLight.intensity = intensity;


    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
        playerLight.intensity = intensity;
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();
    }
}

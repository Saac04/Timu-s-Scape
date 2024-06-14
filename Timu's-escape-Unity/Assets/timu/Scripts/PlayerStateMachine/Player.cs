using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    private bool isDead = false;


    // Variable para rastrear si el jugador est� saltando
    private bool isJumping = false;

    public delegate void JumpAction();
    public static event JumpAction OnJump;

    // Evento para notificar la muerte
    public delegate void DeathAction();
    public static event DeathAction OnDeath;

    public AudioSource audioControllerTimu;
    public List<AudioClip> timuAudioList_Salta;
    public AudioClip timuAudio_CargaSalto;
    public AudioClip timuAudio_CaeSuelo;
    public AudioClip timuAudio_Mueve;

    public Transform timuTransform;
    public ParticleSystem caidaEnLava;

    private bool isShrinking = false;
    private bool isAntiShrinking = false;
    private float shrinkingTime;
    private float timeElapsed=0f;

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

        Application.targetFrameRate = 60;

    }

    private void Update()
    {
        StateMachine.CurrentState.Update();
        playerLight.intensity = intensity;

        // Detecta si el jugador salta y cambia isJumping a true
        if (Input.GetKeyDown(KeyCode.Space) && Time.timeScale!=0f)
        {
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.FixedUpdate();

        // Detecta el salto y notifica a los suscriptores
        if (isJumping)
        {
            isJumping = false;
            OnJump?.Invoke();
        }

        if(isShrinking && Time.time < shrinkingTime){
            timeElapsed += Time.fixedDeltaTime;

            float timePercentage = Mathf.Clamp01(timeElapsed / 0.25f);

            float interpolatedShrinkScale = Mathf.Lerp(1f, 0.9f, timePercentage);
            Vector3 scalebase = Vector3.one * interpolatedShrinkScale;
            timuTransform.localScale = scalebase;
        } else if(isShrinking && Time.time >= shrinkingTime){
            isShrinking=false;
            isAntiShrinking=true;
            shrinkingTime = Time.time + 0.25f;
        }

        if (isAntiShrinking && Time.time < shrinkingTime)
        {
            timeElapsed += Time.fixedDeltaTime;

            float timePercentage = Mathf.Clamp01(timeElapsed / 0.25f);

            float interpolatedShrinkScale = Mathf.Lerp(0.9f, 1f, timePercentage);
            Vector3 scalebase = Vector3.one * interpolatedShrinkScale;
            timuTransform.localScale = scalebase;
        }
        else if (isAntiShrinking && Time.time >= shrinkingTime)
        {
            isShrinking = false;
            isAntiShrinking = false;
        }


    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isDead && other.CompareTag("Lava"))
        {
            Die();
        }
    }

    private void Die()
    {
        isDead = true;
        // Invoca el evento de muerte
        OnDeath?.Invoke();

        StartCoroutine(espera());
    }

    public void shrinkingAnim(){
        isShrinking = true;
        shrinkingTime = Time.time + 0.25f;
    }

    private IEnumerator espera()
    {
        yield return new WaitForSeconds(1f);

        isDead = false;

        yield return null;
    }
}

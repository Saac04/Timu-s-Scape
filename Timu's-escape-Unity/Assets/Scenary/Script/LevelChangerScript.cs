using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animatorController;
    public CameraPartChanger changeCamera;
    public ParticleSystem particleSystem;

    // Definir variables para el tamaño, duración y velocidad de las partículas
    public float particleSize = 4.0f;    
    public float particleSpeed = 9.0f;
    public int particleCount = 50;

    public 

    void Start()
    {
        animatorController.Play("AnimationFadeInWhite");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animatorController.Play("AnimationFadeOutWhite");

            // Modificar las propiedades del ParticleSystem
            var mainModule = particleSystem.main;
            mainModule.startSize = particleSize;
            mainModule.startSpeed = particleSpeed;

            var emissionModule = particleSystem.emission;
            emissionModule.rateOverTime = particleCount;


            Invoke("ChangeToNextScene", 1f);
        }
    }



    void ChangeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        changeCamera.GetComponent<CameraPartChanger>();
        changeCamera.ChangeCameraPos(0);
    }
}

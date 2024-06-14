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

    public AudioSource audioLevelChanger;
    void Start()
    {

        animatorController.Play("AnimationFadeInWhite");
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeScene("Nivel_1");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeScene("Nivel_2");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeScene("VictoryScreen");
            }
            else if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                ChangeScene("Nivel_0");
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            audioLevelChanger.Play();
            animatorController.Play("AminationFadeOutWhite");
            Invoke("ChangeToNextScene", 1f);
        }
    }



    void ChangeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ChangeScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}
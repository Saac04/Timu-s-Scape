using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChangerScript : MonoBehaviour
{
    public Animator animatorController;

    void Start()
    {
        animatorController.Play("AnimationFadeInWhite");
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colision");
        if (other.CompareTag("Player"))
        {
            Debug.Log("Me he activado");
            animatorController.Play("AminationFadeOutWhite");
            Invoke("ChangeToNextScene", 1f);
        }
    }

    void ChangeToNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

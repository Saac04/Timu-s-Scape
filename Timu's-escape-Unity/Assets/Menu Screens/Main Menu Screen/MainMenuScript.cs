using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //SceneManager.LoadScene("SampleScene");

        //Ambas hacen lo mismo
    }

    public void Cerrar()
    {
        Debug.Log("Cerrando juego");
        Application.Quit();
    }

    private void Start() {
        PlayerPrefs.SetInt("jumpCount", 0);
        PlayerPrefs.SetInt("deathCount", 0);
        PlayerPrefs.SetFloat("timerCount", 0f);
        PlayerPrefs.SetInt("collectibleCount", 0);
    }
}

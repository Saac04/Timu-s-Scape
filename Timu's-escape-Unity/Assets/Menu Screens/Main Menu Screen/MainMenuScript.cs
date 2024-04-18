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

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("El jugador salio del juego");
    }
}
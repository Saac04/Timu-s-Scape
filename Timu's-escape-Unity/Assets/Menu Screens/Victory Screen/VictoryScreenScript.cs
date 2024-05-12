using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class VictoryScreenScript : MonoBehaviour
{
    public void ChangeScene(int sceneOrder)
    {
        Debug.Log("Hola " + sceneOrder);
        SceneManager.LoadScene(sceneOrder);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel_1");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    void Start()
    {
        //ShowStats()

        PlayerPrefs.SetInt("jumpCount", 0);
        PlayerPrefs.SetInt("deathCount", 0);
        PlayerPrefs.SetString("timerCount", "");
        
    }

}

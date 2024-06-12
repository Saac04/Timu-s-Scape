using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Agregar la directiva correcta
using UnityEngine.UI;
using System;

public class VictoryScreenScript : MonoBehaviour
{
    private int jumpCount;
    private int deathCount;
    private int collectibleCount;
    private float timeCountF;
    private TimeSpan timeCountTS;

    public Text timeCountText;
    public Text jumpCountText;
    public Text deathCountText;
    public Text collectibleCountText;
    public Text teasingText; // Añadir una nueva variable para el texto de "Teasing"

    public AudioSource audioController;
    public List<AudioClip> sonidosFinalesList;

    void Awake()
    {
        jumpCount = PlayerPrefs.GetInt("jumpCount", 0);
        deathCount = PlayerPrefs.GetInt("deathCount", 0);
        timeCountF = PlayerPrefs.GetFloat("timerCount", 0f);
        collectibleCount = PlayerPrefs.GetInt("collectibleCount", 0);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Nivel_0");
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }

    void Start()
    {
        ShowStats();

        PlayerPrefs.SetInt("jumpCount", 0);
        PlayerPrefs.SetInt("deathCount", 0);
        PlayerPrefs.SetFloat("timerCount", 0f);
        PlayerPrefs.SetInt("collectibleCount", 0);

        StartCoroutine(pirateAudios());
    }

    public void ShowStats()
    {
        timeCountTS = TimeSpan.FromSeconds((double)timeCountF);
        string timeCountStr = "Tiempo: " + timeCountTS.ToString("mm':'ss':'ff");
        timeCountText.text = timeCountStr;

        jumpCountText.text = "Saltos: " + jumpCount.ToString();

        deathCountText.text = "Muertes: " + deathCount.ToString();

        collectibleCountText.text = "Coleccionables: " + collectibleCount.ToString() + "/6";

        teasingText.text = GenerateTeasingMessage(collectibleCount);
    }

    private string GenerateTeasingMessage(int collectibles)
    {
        if (collectibles == 0)
        {
            return "'¿Ni un solo coleccionable? ¿Estás bromeando? Creo que esperaba demasiado'";
        }
        else if (collectibles > 0 && collectibles < 3)
        {
            return "'Si en una partida de póker, no identificas al imbécil, el imbécil eres tu'";
        }
        else if (collectibles >= 3 && collectibles < 6)
        {
            return "'En el diccionario español 'listo' tiene 2 acepciones, y tu no eres ninguna de ellas'";
        }
        else if (collectibles == 6)
        {
            return "'Hostia Ignacio mira que pedazo truño he soltado'";
        }
        else
        {
            return "Mensaje de burla";
        }
    }
    private IEnumerator pirateAudios()
    {
        yield return new WaitForSeconds(40f);

        audioController.PlayOneShot(sonidosFinalesList[0]);

        yield return new WaitForSeconds(15f);

        audioController.PlayOneShot(sonidosFinalesList[1]);

        yield return new WaitForSeconds(10f);

        audioController.PlayOneShot(sonidosFinalesList[2]);

        yield return new WaitForSeconds(5f);

        audioController.PlayOneShot(sonidosFinalesList[3]);
    }
}

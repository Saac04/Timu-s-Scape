using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{

    //[SerializeField] private GameObject botonPausa;

    [SerializeField] private GameObject menuPausa;

    //[SerializeField] private GameObject timer;

    private bool juegoPausado= false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (juegoPausado)
            {
                Reanudar();
            }
            else
            {
                Pausa();
            }

        }
    }
    public void Pausa()
    {
        juegoPausado = true;
        Time.timeScale = 0f;
        //botonPausa.SetActive(false);
        menuPausa.SetActive(true);
        //timer.SetActive(true);
    }

    public void Reanudar()
    {
        juegoPausado = false;
        Time.timeScale = 1f;
        //botonPausa.SetActive(true);
        menuPausa.SetActive(false);
        //timer.SetActive(false);
    }


    public void Cerrar()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenuScene");
    }
}
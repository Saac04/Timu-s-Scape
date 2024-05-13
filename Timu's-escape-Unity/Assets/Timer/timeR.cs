using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class timeR : MonoBehaviour
{
    public static timeR instanciar;
    public Text Crono;
    private TimeSpan tiempoCrono;
    private bool timerBool;
    private float tiempoTrans;
    private float finalTime;


    private void Awake()
    {
        instanciar = this;

    }

    private void Start()
    {
        finalTime = PlayerPrefs.GetFloat("timerCount", 0);
        tiempoCrono = TimeSpan.FromSeconds((double) finalTime);
        string tiempoCronoStr = "Tiempo: " + tiempoCrono.ToString("mm':'ss':'ff");
        Crono.text = tiempoCronoStr;
        timerBool = false;
    }

    public void iniciarTiempo()
    {
        timerBool = true;
        tiempoTrans = finalTime;

        StartCoroutine(ActUpdate());
    }

    void OnDestroy()
    {
        FinTiempo();
        finalTime = (float) tiempoCrono.TotalSeconds;
        PlayerPrefs.SetFloat("timerCount", finalTime);
    }

    public void FinTiempo()
    {
        timerBool = false;
    }

    private IEnumerator ActUpdate()
    {
        while (timerBool)
        {
            tiempoTrans += Time.deltaTime;
            tiempoCrono = TimeSpan.FromSeconds(tiempoTrans);
            string tiempoCronoStr = "Tiempo: " + tiempoCrono.ToString("mm':'ss':'ff");
            Crono.text = tiempoCronoStr;

            yield return null;
        }
    }
}

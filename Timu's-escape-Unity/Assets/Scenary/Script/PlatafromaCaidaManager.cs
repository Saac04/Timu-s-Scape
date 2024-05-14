using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatafromaCaidaManager : MonoBehaviour
{
    public PlataformaCaida plataformaCaida;
    public List<Vector3> originalPosition = new List<Vector3>();
    void Start()
    {
        GameObject[] plataformas = GameObject.FindGameObjectsWithTag("PlataformaCaida");

        foreach (GameObject plataforma in plataformas)
        {
            Transform index = plataforma.GetComponent<Transform>();
            originalPosition.Add(index.position);
            Debug.Log(originalPosition);
        }
    }

    public void resetPlataformaCaida()
    {
        GameObject[] plataformas = GameObject.FindGameObjectsWithTag("PlataformaCaida");

        //plataformaCaida.changeIsTouched(false);

        if (plataformas.Length > 0)
        {
            for (global::System.Int32 i = 0; i < plataformas.Length; i++)
            {
                PlataformaCaida plataforma = plataformas[i].GetComponent<PlataformaCaida>();
                if (plataforma != null)
                {
                    //plataforma.istouched = false;
                    plataformas[i].transform.position = originalPosition[i];
                    plataformaCaida.Reappear();
                }
            }
        }
        else
        {
            Debug.LogWarning("No se encontaron plataforma de caida.");
        }
    }
}

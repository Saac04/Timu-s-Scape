using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinTiempo : MonoBehaviour
{
   

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Colision");
        if (collision.CompareTag("Player"))
        {
            timeR.instanciar.FinTiempo();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiedraDeath : MonoBehaviour
{
    public AudioSource audioController;

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Me quemo");
        audioController.Play();
    }
}

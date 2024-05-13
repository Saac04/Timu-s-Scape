using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private int collectibleCount;
    public CollectibleCount collectibleCounter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            collectibleCounter.collectibleCount++;

            Destroy(gameObject);
        }
    }

}
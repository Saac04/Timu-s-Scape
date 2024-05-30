using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private int collectibleCount;
    public CollectibleCount collectibleCounter;
    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetTrigger("Recoger_Collectible");

            collectibleCounter.collectibleCount++;

            StartCoroutine(WaitTimeInSeconds());
        }
    }

    IEnumerator WaitTimeInSeconds(){
        yield return new WaitForSeconds(0.85f);
        Destroy(gameObject);
    }
}
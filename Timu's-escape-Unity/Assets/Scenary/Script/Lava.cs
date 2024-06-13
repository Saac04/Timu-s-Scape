using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float ascensionSpeed = 0.1f;
    public float changeSpeed = 0.1f;
    private Vector3 originalPosition;
    private float originalSpeed;
    public Player player;
    public Animator animator;
    public AudioClip timuDies;
    public AudioSource lavaAudioSource;
    void Start()
    {
        originalPosition = transform.position;
        originalSpeed = ascensionSpeed;
    }

    void Update()
    {
        Vector3 newPosition = transform.position + Vector3.up * ascensionSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject[] checkpointObjects = GameObject.FindGameObjectsWithTag("CheckPoint");

            if (checkpointObjects.Length > 0)
            {
                CheckPoint foundCheckpoint = null;

                foreach (GameObject checkpointObject in checkpointObjects)
                {
                    CheckPoint checkPoint = checkpointObject.GetComponent<CheckPoint>();

                    if (checkPoint.gameObject.transform.position == player.playerData.checkPointPosition)
                    {
                        foundCheckpoint = checkPoint;
                    }
                }
                if (foundCheckpoint != null)
                {
                    lavaAudioSource.PlayOneShot(timuDies);
                    player.caidaEnLava.Play();
                    foundCheckpoint.RespawnPlayer(player.playerData.checkPointPosition);
                }
                else
                {
                    Debug.LogWarning("No checkpoints found.");
                }
            }
            else
            {
                Debug.LogWarning("No checkpoints found.");
            }
        }

        

    }

    public void resetLava()
    {
        transform.position = originalPosition;
        ascensionSpeed = originalSpeed;
        animator.SetTrigger("Idle");
    }
}

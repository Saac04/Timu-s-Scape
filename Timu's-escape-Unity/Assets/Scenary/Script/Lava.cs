using JetBrains.Annotations;
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
    void Start()
    {
        originalPosition = transform.position;
        originalSpeed = ascensionSpeed;

        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ascensionSpeed += changeSpeed;
            Debug.Log("Velocidad aumentada: " + ascensionSpeed);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            ascensionSpeed -= changeSpeed;
            ascensionSpeed = Mathf.Max(0f, ascensionSpeed);
            Debug.Log("Velocidad disminuida: " + ascensionSpeed);
        }

        Vector3 newPosition = transform.position + Vector3.up * ascensionSpeed * Time.deltaTime;
        transform.position = newPosition;
    }

    private void OnTriggerEnter(Collider other)
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
                foundCheckpoint.RespawnPlayer(player.playerData.checkPointPosition);
                Debug.Log("Player is dead");
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

    public void resetLava()
    {
        transform.position = originalPosition;
        ascensionSpeed = originalSpeed;
        Debug.Log("Posición y velocidad originales restauradas.");
    }
}

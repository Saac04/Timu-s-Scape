using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckPoint : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 actualSpawnPoint;
    public Vector3 lastSpawnPoint;
    public Player player;
    
    


    public void RespawnPlayer(Vector3 respawnPosition)
    {


        if (player.playerData != null)
        {
            // Get the saved checkpoint position from PlayerData
            playerObject = GameObject.FindGameObjectWithTag("Player");

            Debug.Log(respawnPosition);

            // Check if the respawn position is valid
            if (respawnPosition != Vector3.zero &&  true)
            {
                playerObject.transform.position = respawnPosition;
                player.PlayerController.rb.velocity = Vector3.zero;
            }
            else
            {
                // Handle the case where there is no saved checkpoint position
                Debug.LogWarning("No checkpoint position saved.");
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        actualSpawnPoint = gameObject.transform.position;
        lastSpawnPoint = player.playerData.checkPointPosition;

        if (other.CompareTag("Player"))
        {

            if(actualSpawnPoint != lastSpawnPoint)
            {
                player.playerData.checkPointPosition = actualSpawnPoint;
                Debug.Log($"Checkpoint saved in {actualSpawnPoint}");
            }
        }
    }
}

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
    public Lava lava;
    public PlatafromaCaidaManager plataformaCaidaManager;

    public void RespawnPlayer(Vector3 respawnPosition)
    {
        

        if (player.playerData != null)
        {
            // Get the saved checkpoint position from PlayerData
            playerObject = GameObject.FindGameObjectWithTag("Player");

            Debug.Log(playerObject);
            // Check if the respawn position is valid
            if (respawnPosition != Vector3.zero &&  true)
            {
                playerObject.transform.position = respawnPosition;
                player.PlayerController.rb.velocity = Vector3.zero;
                lava.resetLava();
                plataformaCaidaManager.resetPlataformaCaida();

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


        if (other.CompareTag("Player"))
        {

            Debug.Log("entramos");

            Debug.Log(actualSpawnPoint + " posicion antes");
            Debug.Log(lastSpawnPoint + " posicion antes");

            actualSpawnPoint = gameObject.transform.position;
            lastSpawnPoint = player.playerData.checkPointPosition;

            Debug.Log(actualSpawnPoint + " posicion despues");
            Debug.Log(lastSpawnPoint + " posicion despues");

            if (actualSpawnPoint != lastSpawnPoint)
            {
                player.playerData.checkPointPosition = actualSpawnPoint;
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer(player.playerData.checkPointPosition);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 actualSpawnPoint;
    public Vector3 lastSpawnPoint;
    public Player player;
    public Lava lava;
    public Animator animator;
    public PlatafromaCaidaManager plataformaCaidaManager;

    public float respawnDelay = 1.2f; // Duración de la espera en segundos

    private bool isRespawning = false;
    private float respawnTime;
    private Vector3 respawnPosition;

    public void RespawnPlayer(Vector3 respawnPosition)
    {
        if (player.playerData != null)
        {
            // Get the saved checkpoint position from PlayerData
            playerObject = GameObject.FindGameObjectWithTag("Player");

            // Check if the respawn position is valid
            if (respawnPosition != Vector3.zero)
            {
                animator.SetTrigger("FadeInDeath");
                this.respawnPosition = respawnPosition; // Guardar la posición de reaparición
                isRespawning = true;
                respawnTime = Time.time + respawnDelay; // Configurar el tiempo objetivo de reaparición
            }
            else
            {
                // Handle the case where there is no saved checkpoint position
                Debug.LogWarning("No checkpoint position saved.");
            }
        }
    }

    private void Update()
    {
        if (isRespawning && Time.time >= respawnTime)
        {
            playerObject.transform.position = respawnPosition;
            player.PlayerController.rb.velocity = Vector3.zero;
            lava.resetLava();
            plataformaCaidaManager.resetPlataformaCaida();
            isRespawning = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer(player.playerData.checkPointPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        actualSpawnPoint = gameObject.transform.position;
        lastSpawnPoint = player.playerData.checkPointPosition;

        if (other.CompareTag("Player"))
        {
            if (actualSpawnPoint != lastSpawnPoint)
            {
                player.playerData.checkPointPosition = actualSpawnPoint;
            }
        }
    }
}

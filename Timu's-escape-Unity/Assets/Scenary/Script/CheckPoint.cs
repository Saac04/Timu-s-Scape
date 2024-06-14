using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckPoint : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 actualSpawnPoint;
    public Vector3 lastSpawnPoint;
    public Player player;
    public Lava lava;
    public Animator animator;
    public PlatafromaCaidaManager plataformaCaidaManager;

    public float respawnDelay; // Duración de la espera en segundos
    private Camera CameraObj;

    private bool isRespawning = false;
    private float respawnTime;
    private Vector3 respawnPosition;
    public Transform positionDown;
    public Material backgroundMaterialDown;
    public Image backgroundImage;
    public void RespawnPlayer(Vector3 respawnPosition)
    {
        if (player.playerData != null)
        {
            // Get the saved checkpoint position from PlayerData
            playerObject = GameObject.FindGameObjectWithTag("Player");

            Debug.Log(playerObject);
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
            CameraObj = Camera.main;
            backgroundImage.material = backgroundMaterialDown;
            CameraObj.transform.position = positionDown.position;
            if (plataformaCaidaManager != null)
            {
                plataformaCaidaManager.resetPlataformaCaida();
            }
            isRespawning = false;
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer(player.playerData.checkPointPosition);
        }
    }

    private void OnTriggerEnter(Collider other)
    {


        if (other.CompareTag("Player"))
        {
            if (actualSpawnPoint != lastSpawnPoint)

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
}

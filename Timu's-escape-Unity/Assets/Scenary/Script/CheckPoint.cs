using System.Collections;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public GameObject playerObject;
    public Vector3 actualSpawnPoint;
    public Vector3 lastSpawnPoint;
    public Player player;
    public Lava lava;
    public Fade fade;
    public PlatafromaCaidaManager plataformaCaidaManager;

    public void RespawnPlayer(Vector3 respawnPosition)
    {
        if (player.playerData != null)
        {
            // Get the saved checkpoint position from PlayerData
            playerObject = GameObject.FindGameObjectWithTag("Player");

            // Check if the respawn position is valid
            if (respawnPosition != Vector3.zero)
            {
                StartCoroutine(RespawnAfterDelay(respawnPosition));
            }
            else
            {
                // Handle the case where there is no saved checkpoint position
                Debug.LogWarning("No checkpoint position saved.");
            }
        }
    }

    private IEnumerator RespawnAfterDelay(Vector3 respawnPosition)
    {
        fade.FadeIn();
        yield return new WaitForSeconds(1);
        playerObject.transform.position = respawnPosition;
        player.PlayerController.rb.velocity = Vector3.zero;
        lava.resetLava();
        plataformaCaidaManager.resetPlataformaCaida();
        fade.FadeOut();
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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer(player.playerData.checkPointPosition);
        }
    }
}

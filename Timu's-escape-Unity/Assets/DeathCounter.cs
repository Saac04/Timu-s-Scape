using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    private int deathCount = 0;
    public Text deathCountText;

    private void Awake()
    {
        UpdateDeathCountText();
    }

    private void OnEnable()
    {
        // Suscribe al evento de muerte del jugador
        Player.OnDeath += IncrementDeathCount;
    }

    private void OnDisable()
    {
        // Desuscribe del evento de muerte del jugador
        Player.OnDeath -= IncrementDeathCount;
    }

    private void IncrementDeathCount()
    {
        // Incrementa el contador de muertes y actualiza el texto
        deathCount++;
        UpdateDeathCountText();
    }

    private void UpdateDeathCountText()
    {
        deathCountText.text = "Muertes: " + deathCount.ToString();
    }
}

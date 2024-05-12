using UnityEngine;
using UnityEngine.UI;

public class DeathCounter : MonoBehaviour
{
    private int deathCount;
    public Text deathCountText;

    private void Awake()
    {
        LoadDeathData();
    }

    void OnDestroy()
    {
        SaveDeathData();
    }

    void Start()
    {
        deathCountText.text = "Saltos: " + deathCount.ToString();
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
        deathCountText.text = "Muertes: " + deathCount.ToString();
    }

    private void LoadDeathData()
    {
        deathCount = PlayerPrefs.GetInt("deathCount", 0);
    }

    private void SaveDeathData()
    {
        PlayerPrefs.SetInt("deathCount", deathCount);
    }
}
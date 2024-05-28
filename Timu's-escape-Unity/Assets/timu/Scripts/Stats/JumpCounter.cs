using UnityEngine;
using UnityEngine.UI;

public class JumpCounter : MonoBehaviour
{
    private int jumpCount;
    public Text jumpCountText;

    private void Awake()
    {
        LoadJumpData();
    }

    void OnDestroy()
    {
        SaveJumpData();
    }

    void Start()
    {
        if(jumpCountText == null){return;}
        jumpCountText.text = "Saltos: " + jumpCount.ToString();
    }

    private void OnEnable()
    {
        Player.OnJump += IncrementJumpCount;
        
    }

    private void OnDisable()
    {
        Player.OnJump -= IncrementJumpCount;
    }

    private void IncrementJumpCount()
    {
        jumpCount++;
        if (jumpCountText == null) { return; }
        jumpCountText.text = "Saltos: " + jumpCount.ToString();
    }

    private void LoadJumpData()
    {
        jumpCount = PlayerPrefs.GetInt("jumpCount", 0);
    }

    private void SaveJumpData()
    {
        PlayerPrefs.SetInt("jumpCount", jumpCount);
    }
}

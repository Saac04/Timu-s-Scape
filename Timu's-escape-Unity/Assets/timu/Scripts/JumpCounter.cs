using UnityEngine;
using UnityEngine.UI;

public class JumpCounter : MonoBehaviour
{
    private int jumpCount = 0;
    public Text jumpCountText;

    private void Awake()
    {
        jumpCountText.text = "Jumps: " + jumpCount.ToString();
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
        jumpCountText.text = "Saltos: " + jumpCount.ToString();
    }
}

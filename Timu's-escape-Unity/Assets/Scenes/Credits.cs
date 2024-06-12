using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    void Start()
    {
        Invoke("WaitToEnd", 10);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenuScene");
        }
    }
    public void WaitToEnd()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreenScript : MonoBehaviour
{
    public void ChangeScene(int sceneOrder)
    {
        Debug.Log("Hola " + sceneOrder);
        SceneManager.LoadScene(sceneOrder);
    }
}

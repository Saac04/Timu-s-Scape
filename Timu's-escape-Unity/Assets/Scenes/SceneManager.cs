using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    // Nombres de las escenas a las que quieres cambiar
    public string scene1;
    public string scene2;

    void Update()
    {
        // Verifica si Control y 1 están presionados al mismo tiempo
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeScene(scene1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeScene(scene2);
            }
        }
    }

    void ChangeScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogError("Scene name is not set!");
        }
    }
}

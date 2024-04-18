using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPartChanger : MonoBehaviour
{
    Camera CameraObj;

    public Transform positionUp;
    public Transform positionDown;

    void Start()
    {
        CameraObj = Camera.main;
    }

    public void ChangeCameraPos(int whereTo)
    {
        // whereTo indica si la camara debe ir hacia arriba (1) o hacia abajo (0)
        if (whereTo == 1)
        {
            CameraObj.transform.position = positionUp.position;
        } 
        else if(whereTo == 0)
        {
            CameraObj.transform.position = positionDown.position;
        } else
        {
            Debug.Log("No se ha especificado si subir o bajar");
        }
    }

}

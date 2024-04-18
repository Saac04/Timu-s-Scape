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

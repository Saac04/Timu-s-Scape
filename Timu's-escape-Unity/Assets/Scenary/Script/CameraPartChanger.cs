using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CameraPartChanger : MonoBehaviour
{
    Camera CameraObj;

    public Transform positionUp;
    public Transform positionDown;

    public Image backgroundImage;
    public Material backgrounMaterialUp;
    public Material backgroundMaterialDown;

    void Start()
    {
        CameraObj = Camera.main;
    }

    public void ChangeCameraPos(int whereTo)
    {
        // whereTo indica si la camara debe ir hacia arriba (1) o hacia abajo (0)
        if (whereTo == 1)
        {
            backgroundImage.material = backgrounMaterialUp;
            CameraObj.transform.position = positionUp.position;
        } 
        else if(whereTo == 0)
        {
            backgroundImage.material = backgroundMaterialDown;
            CameraObj.transform.position = positionDown.position;
        } else
        {
            Debug.Log("No se ha especificado si subir o bajar");
        }
    }

}

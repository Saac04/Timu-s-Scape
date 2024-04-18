using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPartChangerThreshholdCollider : MonoBehaviour
{
    public int changeTo; //0 significa abajo, 1 significa arriba
    public GameObject cameraPartController;
    public CameraPartChanger cameraScript;
    void Start()
    {
        cameraScript = cameraPartController.GetComponent<CameraPartChanger>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraScript.ChangeCameraPos(changeTo);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 Target;
    public GameObject player;
    public CameraPartChanger changeCamera;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player")){
            Debug.Log("existe");
            player.transform.position = Target;
            changeCamera.ChangeCameraPos(1);
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Vector3 Target;
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        player.transform.position = Target;
    }
}

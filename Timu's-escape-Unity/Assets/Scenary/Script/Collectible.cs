using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{

    public PlayerData playerData;
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            Destroy(gameObject);
            
            
            playerData.recolectedGems++;
            Debug.Log(playerData.recolectedGems);

        }

    }
}

//object pulling
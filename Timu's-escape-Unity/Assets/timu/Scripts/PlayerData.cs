using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float moveSpeed;
    public float jumpForce;
    public float direcctionHorizontal;
    public float maxJumpForce;
    public float deaths;
    public float recolectedGems;
    public float totalJumps;

    public PlayerData() {
        moveSpeed = 5f;
        jumpForce = 5f;
        maxJumpForce = 10f;

    }

}

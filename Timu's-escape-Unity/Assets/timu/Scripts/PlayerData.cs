using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float customGravity = -16f;
    public float moveSpeed = 4f;
    public float minJumpForce = 5f;
    public float maxJumpForce = 22f;
    public float maxJumpTimer = 2f;
    public float jumpSpeedHorizontal = 8f;
    public float jumpForce;
    public float direcctionHorizontal;
    public float deaths;
    public float recolectedGems;
    public float totalJumps;
    public bool IsDead = false;    
}
 
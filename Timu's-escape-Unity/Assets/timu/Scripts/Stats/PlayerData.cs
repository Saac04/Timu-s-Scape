using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
    public float totalJumps;
    public Vector3 checkPointPosition;
}
 
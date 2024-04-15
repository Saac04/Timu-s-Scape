using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController characterController;

    public float moveSpeed = 5f;       
    public float horizontalInput {get; private set; }
 
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirection = new Vector3(horizontalInput, 0f, 0f).normalized;

        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);

    }
}

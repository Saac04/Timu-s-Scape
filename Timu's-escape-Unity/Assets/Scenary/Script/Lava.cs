using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float ascensionSpeed = 0.1f;
    public float changeSpeed = 0.1f;
    private Vector3 orginalPosition;
    private float originalSpeed;

    void Start()
    {
        orginalPosition = transform.position;
        originalSpeed = ascensionSpeed;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ascensionSpeed += changeSpeed;
            Debug.Log("Velocidad aumentada: " + ascensionSpeed);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            ascensionSpeed -= changeSpeed;
            ascensionSpeed = Mathf.Max(0f, ascensionSpeed);
            Debug.Log("Velocidad disminuida: " + ascensionSpeed);
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            transform.position = orginalPosition;
            ascensionSpeed = originalSpeed;
            Debug.Log("Posición y velocidad originales restauradas.");
        }

        Vector3 newPosition = transform.position + Vector3.up * ascensionSpeed * Time.deltaTime;

        transform.position = newPosition;

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El personaje ha tocado la lava. ¡Game Over!");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    public float velocidadAscenso = 0.1f; // Velocidad de ascenso del objeto Lava
    public float cambioVelocidad = 0.1f; // Incremento/decremento de velocidad al presionar +/-
    private Vector3 posicionOriginal;
    private float velocidadOriginal;

    void Start()
    {
        // Guardar la posición y velocidad original de la lava
        posicionOriginal = transform.position;
        velocidadOriginal = velocidadAscenso;
    }

    void Update()
    {
        // Verificar si se presiona la tecla "W" para aumentar la velocidad
        if (Input.GetKeyDown(KeyCode.W))
        {
            velocidadAscenso += cambioVelocidad; // Aumentar la velocidad
            Debug.Log("Velocidad aumentada: " + velocidadAscenso);
        }
        // Verificar si se presiona la tecla "S" para disminuir la velocidad
        else if (Input.GetKeyDown(KeyCode.S))
        {
            velocidadAscenso -= cambioVelocidad; // Disminuir la velocidad
            velocidadAscenso = Mathf.Max(0f, velocidadAscenso); // Asegurarse de que la velocidad no sea negativa
            Debug.Log("Velocidad disminuida: " + velocidadAscenso);
        }
        // Verificar si se presiona la tecla "R" para restaurar la posición y velocidad original
        else if (Input.GetKeyDown(KeyCode.R))
        {
            // Restaurar la posición y velocidad original de la lava
            transform.position = posicionOriginal;
            velocidadAscenso = velocidadOriginal;
            Debug.Log("Posición y velocidad originales restauradas.");
        }

        // Obtener la nueva posición del objeto Lava
        Vector3 nuevaPosicion = transform.position + Vector3.up * velocidadAscenso * Time.deltaTime;

        // Actualizar la posición del objeto Lava
        transform.position = nuevaPosicion;
    }
}

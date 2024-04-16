using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 5f;
    public float horizontalInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    // Función para verificar la capa en la que está el jugador
    public int CheckGround()
    {
        // Lanzar un rayo hacia abajo desde el centro del jugador
        RaycastHit hit;

        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f;

        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, 0.1f))
        {
            Debug.Log (hit.collider.gameObject.layer);
            return hit.collider.gameObject.layer;
        }

        return -1; // Si no hay contacto con la capa especificada, devolverá -1
    }

    // Función para verificar si el jugador está en la capa de suelo
    public bool IsOnGround()
    {
        return CheckGround() == 8; // Comprueba si la capa actual es la capa de suelo (layer 8)
    }
}

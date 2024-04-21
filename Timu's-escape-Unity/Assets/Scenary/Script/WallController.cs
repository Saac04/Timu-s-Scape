using UnityEngine;

public class WallController : MonoBehaviour
{
    public float bounceForce = 3f;

    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si el objeto con el que colisionamos tiene un Rigidbody
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {
            // Calcular la dirección opuesta a la normal de la colisión
            Vector3 bounceDirection = -collision.contacts[0].normal;

            // Aplicar la fuerza de rebote
            otherRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}


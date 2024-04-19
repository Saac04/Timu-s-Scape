using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private bool collisionHandled = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collisionHandled && collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            if (playerRb != null)
            {
                ContactPoint contact = collision.contacts[0];
                Vector3 normal = contact.normal;

                // Debug para imprimir la normal de la colisión
                Debug.Log("Normal de la colisión: " + normal);

                if (normal != Vector3.down)
                {
                    // Si la normal de la colisión no apunta hacia abajo, considerar que es una pared
                    Debug.Log("Rebote");
                    Vector3 newVelocity = Vector3.Reflect(playerRb.velocity, normal);
                    playerRb.velocity = newVelocity;
                }
                else
                {
                    // Si la colisión es con el suelo, imprime un mensaje de depuración
                    Debug.Log("Suelo");
                }

                collisionHandled = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collisionHandled && collision.gameObject.CompareTag("Player"))
        {
            collisionHandled = false;
        }
    }
}

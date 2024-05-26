using UnityEngine;

public class WallController : MonoBehaviour
{
    public float bounceForce = 8f;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        if (otherRigidbody != null)
        {

            Vector3 bounceDirection = -collision.contacts[0].normal;
            otherRigidbody.AddForce(bounceDirection * bounceForce, ForceMode.Impulse);
        }
    }
}
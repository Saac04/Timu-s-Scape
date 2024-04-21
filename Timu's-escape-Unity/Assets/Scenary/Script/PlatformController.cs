using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float raycastDistance = 0.1f;
    private bool playerDetected = false;
    public int numRays = 5;

    private void Update()
    {
        float platformWidth = transform.localScale.x;
        float raySpacing = platformWidth / (numRays - 1);
        Vector3 raycastOriginRight = transform.position - Vector3.right * (platformWidth / 2f);
        Vector3 raycastOriginLeft = transform.position + Vector3.right * (platformWidth / 2f);
        bool playerInSight = false;

        for (int i = 0; i < numRays; i++)
        {
            
            RaycastHit hit;
            Vector3 rayDirection = transform.right;
            Vector3 rayOrigin = raycastOriginRight + Vector3.right * (i * raySpacing);
            Debug.DrawRay(rayOrigin, rayDirection*10f, Color.red);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;

                    if (!playerDetected)
                    {
                        ApplyRebound(hit.collider.attachedRigidbody, Vector3.left);
                        playerDetected = true;
                    }
                }
            }
        }

        for (int i = 0; i < numRays; i++)
        {
            RaycastHit hit;
            Vector3 rayDirection = -transform.right;
            Vector3 rayOrigin = raycastOriginLeft + Vector3.left * (i * raySpacing);
            Debug.DrawRay(rayOrigin, rayDirection, Color.blue);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;

                    if (!playerDetected)
                    {
                        ApplyRebound(hit.collider.attachedRigidbody, Vector3.right);
                        playerDetected = true;
                    }
                }
            }
        }

        if (!playerInSight)
        {
            playerDetected = false;
        }
    }

    private void ApplyRebound(Rigidbody playerRb, Vector3 direction)
    {
        if (playerRb != null)
        {
            Vector3 reflectedVelocity = Vector3.Reflect(playerRb.velocity, direction);
            reflectedVelocity.y = playerRb.velocity.y;
            playerRb.velocity = reflectedVelocity;
            Debug.Log("Velocidad original: " + playerRb.velocity);
            Debug.Log("Nueva velocidad después del rebote: " + reflectedVelocity);
        }
    }
}
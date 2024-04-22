using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float raycastDistance = 0.3f;
    private bool playerDetected = false;

    const float skinwidth = -0.05f;
    public int horizontalRayCount = 6;
    public int verticalRayCount = 6;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    RaycastOrigins raycastOrigins;
    Collider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<Collider>();
    }

    void Update()
    {
        UpdateRaycastOrigins();
        CalculateRaySpacing();

        Vector3 raycastOriginRight = raycastOrigins.bottomRight;
        Vector3 raycastOriginLeft = raycastOrigins.bottomLeft;
        bool playerInSight = false;

        for (int i = 0; i < horizontalRayCount; i++)
        {

            RaycastHit hit;
            Vector3 rayDirection = transform.right;
            Vector3 rayOrigin = raycastOriginRight + Vector3.up * horizontalRaySpacing * i;

            Debug.DrawRay(rayOrigin, rayDirection, Color.red);

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

        for (int i = 0; i < horizontalRayCount; i++)
        {
            RaycastHit hit;
            Vector3 rayDirection = -transform.right;
            Vector3 rayOrigin = raycastOriginLeft + Vector3.up * horizontalRaySpacing * i;
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
        for (int i = 0; i < verticalRayCount; i++)
        {
            RaycastHit hit;
            Vector3 rayDirection = -transform.up;
            Vector3 rayOrigin = raycastOrigins.bottomLeft + Vector3.right * (i * horizontalRaySpacing);
            Debug.DrawRay(raycastOrigins.bottomLeft + Vector3.right * verticalRaySpacing * i, Vector3.up * -2, Color.green);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, 0.1f))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;

                    if (!playerDetected)
                    {
                        ApplyRebound(hit.collider.attachedRigidbody, Vector3.up);
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
            Vector3 halfReflectedVelocity = Vector3.Reflect(playerRb.velocity, direction) * 0.5f;
            halfReflectedVelocity.y = playerRb.velocity.y;
            playerRb.velocity = halfReflectedVelocity;
        }
    }



    void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinwidth);

        raycastOrigins.bottomLeft = new Vector3(bounds.min.x, bounds.min.y);
        raycastOrigins.bottomRight = new Vector3(bounds.max.x, bounds.min.y);
        raycastOrigins.topLeft = new Vector3(bounds.min.x, bounds.max.y);
        raycastOrigins.topRight = new Vector3(bounds.max.x, bounds.max.y);
    }

    void CalculateRaySpacing()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinwidth);

        horizontalRayCount = Mathf.Clamp(horizontalRayCount, 2, int.MaxValue);
        verticalRayCount = Mathf.Clamp(verticalRayCount, 2, int.MaxValue);

        horizontalRaySpacing = bounds.size.y / (horizontalRayCount - 1);
        verticalRaySpacing = bounds.size.x / (verticalRayCount - 1);
    }

    struct RaycastOrigins
    {
        public Vector3 topLeft, topRight, bottomLeft, bottomRight;
    }
}

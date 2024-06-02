using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public float raycastDistance = 0.3f;
    private bool playerDetected = false;

    const float skinwidth = 0f;
    public int horizontalRayCount = 6;
    public int verticalRayCount = 6;

    float horizontalRaySpacing;
    float verticalRaySpacing;

    RaycastOrigins raycastOrigins;
    BoxCollider boxCollider;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        CalculateRaySpacing();
        UpdateRaycastOrigins();
    }

    void FixedUpdate()
    {
        Vector3 raycastOriginRight = raycastOrigins.bottomRight;
        Vector3 raycastOriginLeft = raycastOrigins.bottomLeft;
        bool playerInSight = false;

        for (int i = 0; i < horizontalRayCount; i++)
        {
            RaycastHit hit;
            Vector3 rayDirection = transform.right;
            Vector3 rayOrigin = raycastOriginRight + Vector3.up * horizontalRaySpacing * i;

            Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.red);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;
                    Rigidbody playerRb = hit.collider.attachedRigidbody;
                    PlayerData playerData = hit.collider.GetComponent<Player>().playerData; // Obtener el PlayerData actualizado

                    if (!playerDetected && playerData.direcctionHorizontal != 1)
                    {
                        ApplyRebound(playerRb, Vector3.left);
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

            Debug.DrawRay(rayOrigin, rayDirection * raycastDistance, Color.blue);

            if (Physics.Raycast(rayOrigin, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    playerInSight = true;
                    Rigidbody playerRb = hit.collider.attachedRigidbody;
                    PlayerData playerData = hit.collider.GetComponent<Player>().playerData; // Obtener el PlayerData actualizado

                    if (!playerDetected && playerData.direcctionHorizontal != -1)
                    {
                        ApplyRebound(playerRb, Vector3.right);
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
            playerRb.velocity = new Vector3(reflectedVelocity.x, playerRb.velocity.y, reflectedVelocity.z);

            PlayerData playerData = playerRb.GetComponent<Player>().playerData; // Obtener el PlayerData actualizado
            playerData.direcctionHorizontal *= -1;
        }
    }

    void UpdateRaycastOrigins()
    {
        Bounds bounds = boxCollider.bounds;
        bounds.Expand(skinwidth);

        raycastOrigins.bottomLeft = new Vector3(bounds.min.x, bounds.min.y, bounds.center.z);
        raycastOrigins.bottomRight = new Vector3(bounds.max.x, bounds.min.y, bounds.center.z);
        raycastOrigins.topLeft = new Vector3(bounds.min.x, bounds.max.y, bounds.center.z);
        raycastOrigins.topRight = new Vector3(bounds.max.x, bounds.max.y, bounds.center.z);
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

using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    
    public float horizontalInput;
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

    }

    public bool IsOnGround()
    {
        int numRays = 5;
        
        float raycastWidth = transform.localScale.x;

        float raySpacing = raycastWidth / (numRays - 1);

        Vector3 raycastOrigin = transform.position - Vector3.right * (raycastWidth / 2f);

        for (int i = 0; i < numRays; i++)
        {
            RaycastHit hit;

            if (Physics.Raycast(raycastOrigin + Vector3.right * (i * raySpacing), Vector3.down, out hit, 1.1f, groundLayer))
            {
                return true;
            }
        }

        return false;
    }



}

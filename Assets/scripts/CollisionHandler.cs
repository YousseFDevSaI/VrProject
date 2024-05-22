using System.Diagnostics;
using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    // Adjust these values to change the speed and strength of the force applied
    public float collisionForce = 10f;
    public float collisionSpeed = 1f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            UnityEngine.Debug.LogError("Rigidbody component missing from this GameObject");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Ensure the XR Origin has a Rigidbody component
        if (rb != null)
        {
            // Apply a force in the opposite direction of the collision
            Vector3 forceDirection = collision.contacts[0].normal;
            rb.velocity = Vector3.zero; // Stop any existing movement
            rb.AddForce(forceDirection * collisionForce, ForceMode.Impulse);
        }
    }

    void OnCollisionStay(Collision collision)
    {
        // Ensure the XR Origin has a Rigidbody component
        if (rb != null)
        {
            // Continuously push the XR Origin away from the collision object
            Vector3 forceDirection = collision.contacts[0].normal;
            rb.velocity = forceDirection * collisionSpeed;
        }
    }
}

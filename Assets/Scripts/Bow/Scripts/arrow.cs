using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float arrowLifetime = 5.0f;
    private Rigidbody rb;

    public Material blueMaterial;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(gameObject, arrowLifetime);
    }

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        rb.isKinematic = true;
        if (collision.gameObject.CompareTag("Target"))
        {
            // Change the target's material color (if using a different material for the hit effect)
            Renderer targetRenderer = collision.gameObject.GetComponent<Renderer>();
            targetRenderer.material = blueMaterial; // Assign the blue material to the renderer

            Destroy(gameObject,1f); // Destroy the arrow after hitting the target
        }
    }
}
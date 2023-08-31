using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public float arrowLifetime = 5.0f;
    private Rigidbody rb;

    public Material blueMaterial;
    public Material redMaterial;

    [SerializeField] private AudioClip arrowCollisionImpact;

    Renderer targetRenderer;
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
            Destroy(gameObject, 1f);
        }
        SoundEffectManager.Instance.PlaySoundFXClip(arrowCollisionImpact, transform, .7f);
    }
}
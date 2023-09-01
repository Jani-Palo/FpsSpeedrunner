using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScale : MonoBehaviour
{
    public GameObject objectToScale;
    [SerializeField] private AudioClip hitImpact;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            SoundEffectManager.Instance.PlaySoundFXClip(hitImpact, transform, 1f);
            ScaleOnHit scaleScript = objectToScale.GetComponent<ScaleOnHit>();
            if (scaleScript != null)
            {
                scaleScript.TriggerScale();
            }
        }
    }
}
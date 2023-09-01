using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionSound : MonoBehaviour
{
    [SerializeField] private AudioClip boxImpact;
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        SoundEffectManager.Instance.PlaySoundFXClip(boxImpact, transform, 1f);
    }
}

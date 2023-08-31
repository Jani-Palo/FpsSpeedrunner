using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Collectible data;
    GameManager gameManager;
    [SerializeField] private AudioClip clip;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SoundEffectManager.Instance.PlaySoundFXClip(clip, transform, 1f);
            GameManager.instance.IncrementScore(data.value);
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeSound : MonoBehaviour
{
    public AudioSource audioSource; 

    // T
    public void PlaySound()
    {
        audioSource.Play();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSound : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (PauseMenu.gameIsPaused)
        {
            audioSource.volume = 0;
        }
        if (PauseMenu.gameIsPaused == false)
        {
            audioSource.volume = 0.2f;
        }
    }
}

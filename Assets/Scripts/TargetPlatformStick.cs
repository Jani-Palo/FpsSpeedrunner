using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlatformStick : MonoBehaviour
{
    public Transform player;
    private Transform playerOriginalParent;

    private void Start()
    {
        playerOriginalParent = player.parent; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = playerOriginalParent; 
        }
    }
}
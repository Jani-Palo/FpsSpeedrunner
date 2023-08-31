using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPlatformStick : MonoBehaviour
{
    public Transform player, box;   
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = transform;
            //box.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = null;
            //box.parent = null;
        }
    }
}
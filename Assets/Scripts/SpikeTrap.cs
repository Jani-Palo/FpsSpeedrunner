using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public GameObject Player,spawnPoint;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.GetComponentInChildren<Animator>().Play("SpikeTrap");
            transform.GetComponent<Animator>().Play("SpikeCollider");
            Player.transform.position = spawnPoint.transform.position;
        }
    }
}

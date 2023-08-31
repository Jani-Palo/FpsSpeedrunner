using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpikeTrap : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            transform.GetComponentInChildren<Animator>().Play("SpikeTrap");
            transform.GetComponent<Animator>().Play("SpikeCollider");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

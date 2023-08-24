using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    public Collectible data;
    GameManager gameManager;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.IncrementScore(data.value);
        }

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public bool moveRight = true;
    public Transform player;

    void Update()
    {
        if (moveRight)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        if (transform.position.x >= 10f)
        {
            moveRight = false;
        }
        else if (transform.position.x <= -10f)
        {
            moveRight = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = transform;
            Debug.Log("Player attached to cube");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.parent = null;
            Debug.Log("Player detached from cube");
        }
    }
}

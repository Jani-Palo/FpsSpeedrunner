using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionScale : MonoBehaviour
{
    public GameObject objectToScale; // Reference to the object you want to scale

    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.CompareTag("Arrow")) // Change the tag as needed
        {
            ScaleOnHit scaleScript = objectToScale.GetComponent<ScaleOnHit>();
            if (scaleScript != null)
            {
                scaleScript.TriggerScale();
            }
        }
    }
}
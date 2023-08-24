using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    Collider thisCol;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Level" && (thisCol.enabled = false))
        {
            thisCol.enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    bool collisionsBreakGrag;
    private Rigidbody objectRb;
    private Transform objectGrabPointTransform;
    private void Awake() { 
        objectRb = GetComponent<Rigidbody>();  
    }
    public void Grab(Transform objectGrabPointTransform) { 
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRb.useGravity = false;
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRb.useGravity = true;
    }
    private void FixedUpdate()
    {
        if (objectGrabPointTransform != null)
        {
            float lerpSpeed = 15f;
            Vector3 newPos = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRb.MovePosition(newPos);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collisionsBreakGrag)
        {
            if (objectRb != null)
            {
                objectRb.velocity = Vector3.zero;
                objectRb.angularVelocity = Vector3.zero;
            }
        }
    }
}
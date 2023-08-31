using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    bool collisionsBreakGrag;
    private Rigidbody objectRb;
    private Transform objectGrabPointTransform;
    public GameObject myBow;

    [SerializeField] private AudioClip boxImpact;

    PlayerMovement player;
    private void Awake() {
        objectRb = GetComponent<Rigidbody>();  
    }
    public void Grab(Transform objectGrabPointTransform) { 
        
        this.objectGrabPointTransform = objectGrabPointTransform;
        objectRb.useGravity = false;
        objectRb.isKinematic = true;
        myBow.SetActive(false);
    }
    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRb.isKinematic = false;
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
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        SoundEffectManager.Instance.PlaySoundFXClip(boxImpact, transform, .6f);
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

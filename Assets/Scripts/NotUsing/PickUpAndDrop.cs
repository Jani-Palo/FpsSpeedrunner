using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private LayerMask pickUpLayer;
    [SerializeField] private Transform objectGrabPointTransform;

    RaycastHit hit;

    float pickUpDist = 2f;
    private ObjectGrabbable objectGrabbable;

    bool collisionsBreakGrab;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (objectGrabbable == null)
            {
                if (Physics.Raycast(playerCam.position, playerCam.forward, out hit, pickUpDist, pickUpLayer))
                {
                    Debug.Log(hit.transform);
                    if (hit.transform.TryGetComponent(out objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        if(hit.collider.name == "Box")
                        {
                            hit.collider.enabled = false;
                           
                        }
                       
                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                hit.collider.enabled = true;
                objectGrabbable = null;
            }
        }

    }
    
}
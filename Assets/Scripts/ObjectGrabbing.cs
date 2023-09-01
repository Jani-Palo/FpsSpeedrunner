using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbing : MonoBehaviour
{
    public float maxGrabDistance = 5f; 
    private GameObject currentlyGrabbedObject;
    private Rigidbody grabbedObjectRigidbody;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentlyGrabbedObject == null)
            {
                TryGrabObject();
            }
            else
            {
                ReleaseObject();
            }
        }

        if (currentlyGrabbedObject != null)
        {
            MoveGrabbedObject();
        }
    }

    private void TryGrabObject()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, maxGrabDistance))
        {
            GameObject hitObject = hit.collider.gameObject;
            if (hitObject.CompareTag("Grabbable"))
            {
                GrabObject(hitObject);
            }
        }
    }

    private void GrabObject(GameObject obj)
    {
        currentlyGrabbedObject = obj;
        grabbedObjectRigidbody = obj.GetComponent<Rigidbody>();

        grabbedObjectRigidbody.useGravity = false;
        grabbedObjectRigidbody.isKinematic = true;

        obj.transform.SetParent(transform);
    }

    private void ReleaseObject()
    {
        grabbedObjectRigidbody.useGravity = true;
        grabbedObjectRigidbody.isKinematic = false;

        currentlyGrabbedObject.transform.SetParent(null);

        currentlyGrabbedObject = null;
        grabbedObjectRigidbody = null;
    }

    private void MoveGrabbedObject()
    {
        currentlyGrabbedObject.transform.position = transform.position;
    }
}
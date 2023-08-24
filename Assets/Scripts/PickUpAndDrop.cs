using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndDrop : MonoBehaviour
{
    [SerializeField] private Transform playerCam;
    [SerializeField] private LayerMask pickUpLayer;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) {
            float pickUpDist = 2f;
            if(Physics.Raycast(playerCam.position, playerCam.forward, out RaycastHit raycasthit, pickUpDist, pickUpLayer))
            {

            }
        }
    }
}

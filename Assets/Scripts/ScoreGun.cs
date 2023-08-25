using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGun : MonoBehaviour
{
    public float range = 100f;

    public Camera FPSCam;
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPSCam.transform.position,FPSCam.transform.forward,out hit,range))
        {
            if(hit.transform.tag == "Target")
            {
                Destroy(hit.transform.gameObject);

            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float maxChargeTime = 2.0f;
    public float minShootForce = 10.0f;
    public float maxShootForce = 50.0f;
    private float nextFire = 0.0f;
    public float fireRate = .5f;


    private bool isCharging = false;
    private float currentChargeTime = 0.0f;

    private Animator bowAnimator;

    private void Start()
    {
        bowAnimator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            isCharging = true;
            currentChargeTime = 0.0f;
            bowAnimator.SetTrigger("Draw");
        }

        if (Input.GetKey(KeyCode.Mouse0) && isCharging)
        {

            currentChargeTime += Time.deltaTime;
            currentChargeTime = Mathf.Clamp(currentChargeTime, 0.0f, maxChargeTime);
            bowAnimator.SetBool("IsDrawing", true); // Set the parameter to continue the animation
        }
        else
        {
            bowAnimator.SetBool("IsDrawing", false);
        }
    

        if (Input.GetKeyUp(KeyCode.Mouse0) && isCharging)
        {
            isCharging = false;
            ShootArrow();
        }
        if (!isCharging)
        {
            bowAnimator.SetTrigger("Release");
            currentChargeTime = 0.0f;
        }
       
    }

    private void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody arrowRb = arrow.GetComponent<Rigidbody>();

        float shootForce = Mathf.Lerp(minShootForce, maxShootForce, currentChargeTime / maxChargeTime);
        arrowRb.velocity = arrowSpawnPoint.forward * shootForce;

        currentChargeTime = 0.0f;
    }
}

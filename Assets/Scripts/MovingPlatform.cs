using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;   
    public float moveSpeed = 5f;    
    public float waitTime = 1f;     

    private int currentWaypointIndex = 0;
    private bool movingForward = true;


    private void Start()
    {
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (waypoints.Length == 0)
            return;

        Vector3 targetPosition = waypoints[currentWaypointIndex].position;
        Vector3 moveDirection = (targetPosition - transform.position).normalized;

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            StartCoroutine(WaitAtWaypoint());

            if (movingForward)
            {

                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = waypoints.Length - 1;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 0;
                    movingForward = true;
                }
            }
        }

    }
        private IEnumerator WaitAtWaypoint()
        {
            yield return new WaitForSeconds(waitTime);
        }


       
    }


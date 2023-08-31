using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform player;
    public Transform[] waypoints;   // Array of waypoints the platform will move between
    public float moveSpeed = 5f;    // Speed at which the platform moves
    public float waitTime = 1f;     // Time the platform waits at each waypoint

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

        // Move the platform
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        // Check if the platform has reached the target waypoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            // Wait at the waypoint
            StartCoroutine(WaitAtWaypoint());

            // Update the current waypoint index
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


        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.parent = transform;
                Debug.Log("Player attached to cube");
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                player.parent = null;
                Debug.Log("Player detached from cube");
            }
        }
    }


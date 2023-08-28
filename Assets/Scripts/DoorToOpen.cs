using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorToOpen : MonoBehaviour
{
    public Vector3 openPosition;
    public Vector3 closedPosition;
    public float openSpeed = 2.0f;

    private bool isOpen = false;
    private bool isMoving = false;
    private AudioSource audioSource;

    private void Awake()
    {
        openPosition = new Vector3(transform.position.x,5,transform.position.z);
        closedPosition = transform.position;
        audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        if (!isOpen && !isMoving)
        {
            isOpen = true;
            isMoving = true;
            //audioSource.Play(); 

            StartCoroutine(MoveDoor(openPosition));
        }
    }

    public void Deactivate()
    {
        if (isOpen && !isMoving)
        {
            isOpen = false;
            isMoving = true;
            //audioSource.Play(); // Play door closing sound

            StartCoroutine(MoveDoor(closedPosition));
        }
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Vector3 initialPosition = transform.position;
        float startTime = Time.time;

        while (isMoving)
        {
            float elapsedTime = Time.time - startTime;
            float t = Mathf.Clamp01(elapsedTime / openSpeed);

            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

           

            yield return null;
        }
    }
}
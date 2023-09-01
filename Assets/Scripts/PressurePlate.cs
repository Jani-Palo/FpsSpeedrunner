using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public GameObject door;
    public Collider doorCollider;
    public Vector3 openPosition;
    public Vector3 closedPosition;

    public Vector3 newPos;
    public float moveSpeed = 2.0f;
    public float requiredWeight;
    private bool isActivated = false;
    [SerializeField] private AudioClip PressureImpact;


    private void Start()
    {
        closedPosition = door.transform.position;
        openPosition = closedPosition + newPos;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isActivated )
        {
            if (other.GetComponent<Rigidbody>().mass >= requiredWeight)
            {
                isActivated = true;
                OpenDoor();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isActivated)
        {
            isActivated = false;
            CloseDoor();
        }
    }

    private void OpenDoor()
    {
        SoundEffectManager.Instance.PlaySoundFXClip(PressureImpact, transform, 1f);
        doorCollider.isTrigger = false;
        StopAllCoroutines();
        StartCoroutine(MoveDoor(openPosition));
    }

    private void CloseDoor()
    {
        doorCollider.isTrigger = true;
        StopAllCoroutines();
        StartCoroutine(MoveDoor(closedPosition));
    }

    private IEnumerator MoveDoor(Vector3 targetPosition)
    {
        Vector3 initialPosition = door.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveSpeed)
        {
            door.transform.position = Vector3.Lerp(initialPosition, targetPosition, elapsedTime / moveSpeed);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        door.transform.position = targetPosition;
    }
    
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowSway : MonoBehaviour
{
    public float swayAmount = 1.0f;
    public float maxSwayAngle = 15.0f;
    public float swaySpeed = 2.0f;

    public Vector3 initialTiltAngles = new Vector3(0f, 0f, 0f); // Set initial tilt angles

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private void Start()
    {
        initialPosition = transform.localPosition;
        initialRotation = transform.localRotation * Quaternion.Euler(initialTiltAngles);
    }

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        float tiltX = -mouseY * swayAmount;
        float tiltY = mouseX * swayAmount;

        tiltX = Mathf.Clamp(tiltX, -maxSwayAngle, maxSwayAngle);
        tiltY = Mathf.Clamp(tiltY, -maxSwayAngle, maxSwayAngle);

        Quaternion targetTilt = Quaternion.Euler(initialTiltAngles.x + tiltX, initialTiltAngles.y + tiltY, 0f);

        transform.localRotation = Quaternion.Slerp(transform.localRotation, initialRotation * targetTilt, Time.deltaTime * swaySpeed);

        Vector3 targetPosition = initialPosition + new Vector3(mouseX, mouseY, 0f) * swayAmount;
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * swaySpeed);
    }
}
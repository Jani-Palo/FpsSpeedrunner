using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    private float initialMouseSens = 200f; // Default mouse sensitivity.

    [HideInInspector] public float mouseSens; // Sensitivity adjusted from the MainMenu.

    float xRot = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
       
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        transform.localRotation = Quaternion.Euler(xRot, 0, 0);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
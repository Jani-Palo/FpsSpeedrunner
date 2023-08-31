using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Transform objectTransform;
    public float moveDistance;
    public float openSpeed;

    [Header("Colors")]
    public Renderer objectRenderer;
    public Color initialColor;
    public Color firstColor;
    public Color secondColor;

    private bool isInitialColor = true;


    private bool isOpen = false;
    private Vector3 initialObjectPosition;
    private Vector3 movedTransformPosition;
    public Vector3 newPos;

    [SerializeField] private AudioClip moveSound;
    private void Start()
    {
        objectRenderer.material.color = initialColor;
        initialObjectPosition = objectTransform.position;
        movedTransformPosition = initialObjectPosition + newPos * moveDistance;
    }

    private void Update()
    {
        if (isOpen)
        {
            objectTransform.position = Vector3.Lerp(objectTransform.position, movedTransformPosition, openSpeed * Time.deltaTime);
        }
        else
        {
            objectTransform.position = Vector3.Lerp(objectTransform.position, initialObjectPosition, openSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            SoundEffectManager.Instance.PlaySoundFXClip(moveSound, transform, 1f);
            ToggleMovement();
            ToggleColor();
        }
    }

    public void ToggleMovement()
    {
        isOpen = !isOpen;
        if (isOpen)
        {
            movedTransformPosition = isInitialColor ? initialObjectPosition + newPos * moveDistance : initialObjectPosition;
        }
    }
    private void ToggleColor()
    {
        isInitialColor = !isInitialColor;
        objectRenderer.material.color = isInitialColor ? firstColor : secondColor;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnHit : MonoBehaviour
{
    public float targetScaleAmount = 1.5f;
    public float scaleDuration = 1.0f;
    public bool scaleNegativeX = true;

    private bool isScaling = false;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 originalScale; // Store the original scale before any scaling
    private float startTime;

    private void Start()
    {
        initialScale = transform.localScale;
        originalScale = initialScale;

        if (scaleNegativeX)
        {
            targetScale = new Vector3(initialScale.x - targetScaleAmount, initialScale.y, initialScale.z);
        }
        else
        {
            targetScale = new Vector3(initialScale.x + targetScaleAmount, initialScale.y, initialScale.z);
        }
    }

    private void Update()
    {
        if (isScaling)
        {
            float elapsed = Time.time - startTime;
            float t = Mathf.Clamp01(elapsed / scaleDuration);

            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            if (t >= 1.0f)
            {
                isScaling = false;
            }
        }
    }

    public void TriggerScale()
    {
        if (isScaling)
        {
            targetScale = originalScale; // Scale back to the original size
        }
        else
        {
            if (scaleNegativeX)
            {
                targetScale = new Vector3(initialScale.x - targetScaleAmount, initialScale.y, initialScale.z);
            }
            else
            {
                targetScale = new Vector3(initialScale.x + targetScaleAmount, initialScale.y, initialScale.z);
            }
        }

        isScaling = true;
        startTime = Time.time;
    }
}
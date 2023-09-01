using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnHit : MonoBehaviour
{
    public float targetScaleAmount = 1.5f;
    public float scaleDuration = 1.0f;
    public bool scaleNegativeX = true;

    public Vector3 customScaleChange = Vector3.one;
    public float customScaleDuration = 1.0f;

    private bool isScaling = false;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private Vector3 originalScale;
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
            targetScale = originalScale;
        }
        else
        {
            targetScale = initialScale + customScaleChange;
            scaleDuration = customScaleDuration;
        }

        isScaling = true;
        startTime = Time.time;
    }
}
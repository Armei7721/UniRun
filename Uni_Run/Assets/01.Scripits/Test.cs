using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private bool isScalingUp = false;
    private bool isScalingDown = false;
    private float scaleTimer = 0f;
    private float scaleDuration = 1f;
    private Vector3 initialScale;

    private void Update()
    {
        Invincibility();
        if (isScalingUp)
        {
            scaleTimer += Time.deltaTime;
            float t = scaleTimer / scaleDuration;
            transform.localScale = Vector3.Lerp(initialScale, new Vector3(3f, 3f, 1f), t);

            if (scaleTimer >= scaleDuration)
            {
                isScalingUp = false;
                isScalingDown = true;
                scaleTimer = 0f;
                initialScale = transform.localScale;
            }
        }
        else if (isScalingDown)
        {
            scaleTimer += Time.deltaTime;
            float t = scaleTimer / scaleDuration;
            transform.localScale = Vector3.Lerp(initialScale, new Vector3(1f, 1f, 1f), t);

            if (scaleTimer >= scaleDuration)
            {
                isScalingDown = false;
            }
        }
    }

    private void Invincibility()
    {
        // 이전 코드 내용 유지

        isScalingUp = true;
        scaleTimer = 0f;
        initialScale = transform.localScale;
    }
}
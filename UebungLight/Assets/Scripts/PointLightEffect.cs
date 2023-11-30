using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLightEffect : MonoBehaviour
{
    private Light myLight;
    public float minIntensity = 1f;
    public float maxIntensity = 5f;
    public float minDuration = 1f;
    public float maxDuration = 4f;
    public float minWaitTime = 0.5f;
    public float maxWaitTime = 2f;


    private void Start()
    {
        myLight = gameObject.GetComponent<Light>();

        StartCoroutine("ChangeLightIntensity");
    }

    IEnumerator ChangeLightIntensity()
    {
        while (true)
        {
            float duration = Random.Range(minDuration, maxDuration);
            float waitTime = Random.Range(minWaitTime, maxWaitTime);

            float t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                float smoothedT = SmoothStep(0f, 1f, t);
                myLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, smoothedT);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);

            t = 0f;

            while (t < 1f)
            {
                t += Time.deltaTime / duration;
                float smoothedT = SmoothStep(0f, 1f, t);
                myLight.intensity = Mathf.Lerp(maxIntensity, minIntensity, smoothedT);
                yield return null;
            }

            yield return new WaitForSeconds(waitTime);
        }
    }

    float SmoothStep(float edge0, float edge1, float x)
    {
        // Scale, bias and saturate x to 0..1 range
        x = Mathf.Clamp01((x - edge0) / (edge1 - edge0));
        // Evaluate polynomial
        return x * x * (3 - 2 * x);
    }
}

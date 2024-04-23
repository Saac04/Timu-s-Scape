using UnityEngine;
using System.Collections;


public class MineralLight : MonoBehaviour
{
    private bool LightOnCheck = false;
    public float maxIntensity = 10f;
    public float minIntensity = 1f;
    public float intensityChangeRate = 0.3f;
    public float lightOnTime = 5f;
    private Light mineralLight;

    void Start()
    {
        mineralLight = GetComponent<Light>();
        mineralLight.intensity = minIntensity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !LightOnCheck)
        {
            LightOnCheck = true;
            StartCoroutine(LightUp());
            Invoke("TimeToSleep", lightOnTime);
        }
    }

    IEnumerator LightUp()
    {
        float currentIntensity = minIntensity;
        while (currentIntensity <= maxIntensity)
        {
            mineralLight.intensity = currentIntensity;
            currentIntensity += intensityChangeRate;
            yield return new WaitForSeconds(0.1f); // Adjust for smoother transition
        }
    }

    private void TimeToSleep()
    {
        StartCoroutine(LightDown());
    }

    IEnumerator LightDown()
    {
        float currentIntensity = maxIntensity;
        while (currentIntensity >= minIntensity)
        {
            mineralLight.intensity = currentIntensity;
            currentIntensity -= intensityChangeRate;
            yield return new WaitForSeconds(0.05f); // Adjust for smoother transition
        }
        LightOnCheck = false;
    }
}
using UnityEngine;

public class LightController : MonoBehaviour
{
    private Light mineralLight;
    public float maxRange = 10f;
    public float minRange = 1f;
    public float duration = 7f; // Duración en segundos para alcanzar el rango máximo
    private float elapsedTime = 0f;
    private bool enContacto;
    public AudioSource soundSource;

    

    private void Start()
    {
        mineralLight = GetComponent<Light>();
        mineralLight.range = minRange;
        enContacto = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !enContacto)
        {
            enContacto = true;
            soundSource.Play();
            StartCoroutine(IncreaseLightRange());
        }
    }

    System.Collections.IEnumerator IncreaseLightRange()
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / duration;
            mineralLight.range = Mathf.Lerp(minRange, maxRange, t);
            yield return null;
        }

        mineralLight.range = maxRange; // Asegurar que llegue exactamente al rango máximo

        yield return new WaitForSeconds(1f);

        StartCoroutine(DecreaseLightRange());

    }
    System.Collections.IEnumerator DecreaseLightRange()
    {
        float startTime = Time.time;
        float endTime = startTime + duration;
        

        while (Time.time < endTime)
        {
            float t = (Time.time - startTime) / duration;
            mineralLight.range = Mathf.Lerp(maxRange, minRange, t);
            yield return null;
        }

        mineralLight.range = minRange; // Asegurar que llegue exactamente al rango máximo

        enContacto = false;
    }
}
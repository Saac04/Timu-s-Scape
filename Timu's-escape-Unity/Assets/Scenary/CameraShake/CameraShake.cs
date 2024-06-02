using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float duration = 1.0f;
    public float magnitud = 1.0f;
    public float magnitudFondo = -0.8f;
    public ParticleSystem ParticulasDerrumbe;
    public Canvas FondoCanvas;

    void Start()
    {
        Invoke("StartShake", 1.0f);
    }

    void StartShake()
    {
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
        Vector3 originalPosition = transform.localPosition;
        Vector3 fondoOriginalPosition = FondoCanvas.transform.position;

        float elapsed = 0f;

        ParticulasDerrumbe.Play();

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitud;
            float y = Random.Range(-1f, 1f) * magnitud;

            float fondoX = Random.Range(-1f, 1f) * magnitudFondo;

            transform.localPosition = new Vector3(x, originalPosition.y, originalPosition.z);
            FondoCanvas.transform.position = new Vector3(fondoX, fondoOriginalPosition.y, fondoOriginalPosition.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPosition;
        FondoCanvas.transform.position = fondoOriginalPosition;
    }
}

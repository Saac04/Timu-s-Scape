using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    public float fallWait = 1f;
    public float fallDistance = 2.5f;
    public float fallingspeed = 1f;
    public float destroyWait = 1f;
    public float reappearWait = 5f;
    private Vector3 originalPosition;

    private MeshRenderer[] childRenderers;
    private Collider[] childColliders;
    private GameObject[] childrenObjects;
    private Coroutine reappearCoroutine;
    public AudioSource audioCaida;
    private bool isBreaking;

    public ParticleSystem smokeParticles;

    public void Start()
    {
        isBreaking = false;
        originalPosition = transform.position;

        childColliders = GetComponentsInChildren<Collider>(true);

        childrenObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childrenObjects[i] = transform.GetChild(i).gameObject;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!isBreaking && collision.gameObject.CompareTag("Player"))
        {
            isBreaking = true;
            StartCoroutine(fall());
        }
    }
    private IEnumerator fall()
    {
        audioCaida.Play();

        yield return new WaitForSeconds(fallWait);


        while (transform.position.y > originalPosition.y - fallDistance) // 
        {
            transform.Translate(Vector3.down * fallingspeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Particulas");
        smokeParticles.Play();
        Debug.Log("Espero");
        yield return new WaitForSeconds(destroyWait);

        Debug.Log("Escondo");
        HideChildren();
        reappearCoroutine = StartCoroutine(ReappearAfterDelay());
    }


    public void Reappear()
    {
        if (reappearCoroutine != null)
        {
            StopCoroutine(reappearCoroutine);
        }
        isBreaking = false;
        ShowChildren();
    }

    private IEnumerator ReappearAfterDelay()
    {
        yield return new WaitForSeconds(reappearWait);
        Reappear();
    }

    public void HideChildren()
    {
        foreach (Collider collider in childColliders)
        {
            collider.enabled = false;
        }

        foreach (GameObject child in childrenObjects)
        {
            child.SetActive(false);
        }
    }

    public void ShowChildren()
    {

        transform.position = originalPosition;

        foreach (Collider collider in childColliders)
        {
            collider.enabled = true;
        }

        foreach (GameObject child in childrenObjects)
        {
            child.SetActive(true);
        }
        smokeParticles.Play();
    }
}


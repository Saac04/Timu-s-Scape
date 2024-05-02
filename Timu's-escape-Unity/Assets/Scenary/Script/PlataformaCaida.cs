using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlataformaCaida : MonoBehaviour
{
    public float fallWait = 1f;
    public float fallDistance = 5f;
    public float fallingspeed = 0.4f;
    public float destroyWait = 0f;
    public float reappearWait = 5f;
    private Vector3 originalPosition;

    private MeshRenderer[] childRenderers;
    private Collider[] childColliders;
    private GameObject[] childrenObjects;
    private Coroutine reappearCoroutine;

    public void Start()
    {
        originalPosition = transform.position;

        childColliders = GetComponentsInChildren<Collider>(true);

        childrenObjects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            childrenObjects[i] = transform.GetChild(i).gameObject;
            Debug.Log(childrenObjects[i]);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Momento contacto");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ya tocado");
            StartCoroutine(fall());
        }
    }
    private IEnumerator fall()
    {
        yield return new WaitForSeconds(fallWait);


        while (transform.position.y > originalPosition.y - fallDistance) // 
        {
            transform.Translate(Vector3.down * fallingspeed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(destroyWait);

        HideChildren();
        reappearCoroutine = StartCoroutine(ReappearAfterDelay());
    }


    public void Reappear()
    {
        if (reappearCoroutine != null)
        {
            StopCoroutine(reappearCoroutine);
        }
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
            Debug.Log($"desactivo {child}");
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
    }
}

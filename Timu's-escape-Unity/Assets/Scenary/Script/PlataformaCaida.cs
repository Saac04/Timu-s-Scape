using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaCaida : MonoBehaviour
{
    private float esperaParaCaer = 6f;
    private float esperaParaDestruir = 0.5f;
    public bool istouched = false;
    private float fallingspeed = 4f;
    private Vector3[] originalPosition;
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Momento contacto");
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ya tocado");
            StartCoroutine(Caida());
        }
    }
    private IEnumerator Caida()
    {
        yield return new WaitForSeconds(esperaParaCaer);
        istouched = true;
        //Destroy(this.gameObject, esperaParaDestruir);

    }
    void Update()
    {
        if (istouched)
        {
            Vector3 newPosition = transform.position + Vector3.down * fallingspeed * Time.deltaTime;
            transform.position = newPosition;
        }
    }



}

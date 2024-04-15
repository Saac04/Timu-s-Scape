using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoHorizontal : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento horizontal
    public float alturaMaximaSalto = 15f; // Altura máxima que puede alcanzar el salto
    public float tiempoMaximoSalto = 2f; // Tiempo máximo de carga del salto
    public float fuerzaSaltoMinima = 2f; // Fuerza mínima del salto
    public float velocidadLateralSalto = 1f; // Velocidad lateral del salto
    public float fuerzaRebote = 1f;
    public float tiempoPausaDespuesAterrizaje = 0.5f; // Duración de la pausa en segundos
    private Rigidbody rb;
    private bool enSuelo; // Para verificar si el personaje está en el suelo
    private bool saltando; // Para verificar si el personaje está en proceso de salto
    private float tiempoPresionado; // Tiempo que se ha mantenido presionada la tecla de salto
    private float direccionHorizontal; // Dirección horizontal del salto (-1: izquierda, 1: derecha)
    private int direccionRebote; // Dirección del rebote (-1: izquierda, 1: derecha)
    private bool enPausa = false; // Indica si el personaje está en pausa después del aterrizaje
    private float tiempoInicioPausa; // Tiempo en que comienza la pausa después del aterrizaje
    private bool Salto;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Salto = false;
        // Congelar el desplazamiento en la dirección Z
        rb.constraints |= RigidbodyConstraints.FreezePositionZ;
    }


    void Update()
    {
        // Verificar si el personaje está en pausa después del aterrizaje
        if (enPausa)
        {
            // Si está en pausa, no permitir ningún movimiento
            return;
        }

        // Obtener la entrada del eje horizontal (teclas A, D o flechas izquierda y derecha)
        float movimientoHorizontal = Input.GetAxis("Horizontal");


        // Verificar si se está presionando la tecla de espacio
        if (Input.GetKey(KeyCode.Space))
        {
            saltando = true; // El personaje está cargando salto
        }
        else
        {
            saltando = false; // El personaje no está cargando el salto
        }


        // Calcular el movimiento horizontal solo si no se está cargando salto y el personaje está en el suelo
        if (!saltando && enSuelo && !Salto)
        {
            // Calcular el movimiento horizontal
            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, 0f) * velocidadMovimiento * Time.deltaTime;

            // Aplicar el movimiento al Rigidbody
            rb.MovePosition(rb.position + movimiento);
        }

        // Mantener el seguimiento del tiempo de presión de la tecla de salto
        if (Input.GetKey(KeyCode.Space))
        {
            tiempoPresionado += Time.deltaTime;

            // Limitar el tiempo presionado al tiempo máximo de carga del salto
            tiempoPresionado = Mathf.Clamp(tiempoPresionado, 0f, tiempoMaximoSalto);
        }


        // Si se suelta la tecla de salto y el personaje está en el suelo, saltar
        if (Input.GetKeyUp(KeyCode.Space) && enSuelo && !Salto)
        {
            // Calcular la fuerza del salto basada en el tiempo presionado (función cuadrática)
            float alturaSalto = Mathf.Pow(tiempoPresionado / tiempoMaximoSalto, 2) * alturaMaximaSalto;
            float fuerzaSalto = Mathf.Max(fuerzaSaltoMinima, Mathf.Sqrt(alturaSalto * 2 * Physics.gravity.magnitude));

            // Determinar la dirección horizontal del salto
            if (Input.GetKey(KeyCode.A))
            {
                direccionHorizontal = -1f; // Salto hacia la izquierda
                direccionRebote = 1; // Dirección del rebote
            }
            else if (Input.GetKey(KeyCode.D))
            {
                direccionHorizontal = 1f; // Salto hacia la derecha
                direccionRebote = -1; // Dirección del rebote
            }
            else
            {
                direccionHorizontal = 0f; // No hay dirección horizontal
            }

            // Registro de acción: salto
            Debug.Log("Salto con fuerza: " + fuerzaSalto + ". Tiempo de carga: " + tiempoPresionado + "s");

            // Calcular la velocidad lateral del salto (menos desplazamiento lateral)
            float velocidadLateral = direccionHorizontal * velocidadLateralSalto;

            // Aplicar una fuerza hacia arriba y hacia la dirección del salto para simular el salto
            rb.AddForce(new Vector3(velocidadLateral, fuerzaSalto, 0f), ForceMode.Impulse);
            tiempoPresionado = 0f; // Reiniciar el tiempo presionado para el próximo salto

            Salto = true;
            // Registro de estado: Fuera del suelo
            Debug.Log("Saltando");
        }
    }




    void FixedUpdate()
    {
    // Verificar si el personaje está en pausa después del aterrizaje y ha pasado el tiempo de pausa
    if (enPausa && Time.time >= tiempoInicioPausa + tiempoPausaDespuesAterrizaje)
    {
        // Desactivar la pausa
        enPausa = false;
        Salto = false;
        Debug.Log("Sale de Pausa");

        // Ajusta la posición desde la cual se lanza el Raycast sea un poco por encima del suelo
        Vector3 raycastOrigin = transform.position + Vector3.up * 0.1f;

        // Verificar si el personaje está en el suelo usando un Raycast
        RaycastHit hit;
        if (Physics.Raycast(raycastOrigin, Vector3.down, out hit, 0.1f)) // Lanzar un rayo hacia abajo desde la posición ajustada
        {
            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Suelo"))
            {
                // Está en el suelo
                enSuelo = true;

                // Registro de estado: En Suelo
                Debug.Log("Dentro del suelo");
            }
            else{
                enSuelo = false;

                Debug.Log("Fuera del suelo");
            }
        }
        // Dibujar el rayo en el Editor de Unity
    Debug.DrawRay(raycastOrigin, Vector3.down * 0.1f, Color.red);
    }  
}


    // Método para detectar colisiones
    private void OnCollisionEnter(Collision collision)
    {
        // Verificar si la colisión es con un objeto que pertenece a la capa de suelo
        if (collision.gameObject.layer == LayerMask.NameToLayer("Floor"))
        {
            // Registro de estado: En Suelo
            Debug.Log("Cae al suelo");

            enPausa = true;
            tiempoInicioPausa = Time.time;
            rb.velocity = Vector3.zero;

            Debug.Log("Activar Pausa");
        }

        if (collision.gameObject.CompareTag("Obstacle") && Salto)
        {
            // Obtener la dirección del rebote
            Vector3 direccionReboteVector = Vector3.right * direccionRebote;

            // Aplicar una fuerza de rebote
            rb.AddForce(direccionReboteVector * fuerzaRebote, ForceMode.Impulse);

            // Registro de acción: rebote
            Debug.Log("Rebote con fuerza: " + fuerzaRebote + ". Dirección: " + direccionReboteVector);
        }
        else if (collision.gameObject.CompareTag("Wash"))
        {
            
            enSuelo=false;
            Salto = true;
            direccionRebote = 0;
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            // Teletransportar al personaje al punto (0, 3, 0)
            transform.position = new Vector3(0f, 3f, 0f);

            // Registro de acción: teletransporte
            Debug.Log("Teletransportado a (0, 3, 0)");

            return;
        }
    }


}

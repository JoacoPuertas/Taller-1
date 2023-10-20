using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarMonstruos : MonoBehaviour
{
    public GameObject prefabMonstruo; // Asigna el Prefab de la imagen 2D
    public int vidas = 5; // Cantidad inicial de vidas
    public float velocidad; // Velocidad de movimiento de las im�genes
    public Vector3 posicionInicial = new Vector3(0f, 1.0f, 30.0f);
    public float tiempoEntreSpawn = 2.0f; // Tiempo entre la generaci�n de monstruos

    void Start()
    {
        // Comienza la generaci�n continua de im�genes
        InvokeRepeating("GenerarImagen", 0.0f, tiempoEntreSpawn); // Genera una imagen cada ciertos segundos
    }

    void GenerarImagen()
    {
        // Crea una nueva instancia del Prefab en la posici�n inicial configurada en el Inspector
        GameObject nuevaImagen = Instantiate(prefabMonstruo, posicionInicial, Quaternion.identity);

        // Accede a su componente "MoverImagen2D" y establece la velocidad seg�n la configuraci�n del Inspector
        MoverImagen2D moverImagen = nuevaImagen.GetComponent<MoverImagen2D>();
        if (moverImagen != null)
        {
            moverImagen.velocidad = velocidad;
            moverImagen.limiteZ = -10.0f; // Asigna el l�mite en Z
        }
    }

    void Update()
    {
        // Mueve todas las im�genes generadas hacia el eje Z
        GameObject[] imagenes = GameObject.FindGameObjectsWithTag("Monstruo");

        foreach (GameObject imagen in imagenes)
        {
            imagen.transform.Translate(Vector3.back * velocidad * Time.deltaTime);

            // Verifica si la imagen llega a la posici�n Z = -10
            if (imagen.transform.position.z < -10)
            {
                GameManager.Instance.PerderVida();
                RestarVida();
                Destroy(imagen);
            }
        }
    }

    void RestarVida()
    {
        vidas--; // Resta una vida
        Debug.Log("Vidas restantes: " + vidas);

        // Si deseas cambiar el estado del juego a "perdiste" cuando las vidas llegan a 0, puedes hacerlo aqu�.
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverImagen2D : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento de la imagen
    public float posY; // Posición en Y inicial
    public float limiteZ = -10.0f; // Límite en el eje Z

    void Update()
    {
        // Mueve la imagen en el eje Z
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Verifica si la imagen llega al límite en Z
        if (transform.position.z < limiteZ)
        {
            Destroy(gameObject); // Destruye la imagen en lugar de reiniciar su posición
        }
    }
}
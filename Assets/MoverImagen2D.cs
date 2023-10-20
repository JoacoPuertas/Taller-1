using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverImagen2D : MonoBehaviour
{
    public float velocidad = 2.0f; // Velocidad de movimiento de la imagen
    public int vidas = 5; // Cantidad inicial de vidas
    public float posX;
    public float posY;

    void Update()
    {
        // Mueve la imagen en el eje Z
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);

        // Verifica si la imagen llega a la posición Z = -10
        if (transform.position.z < -10)
        {
            RestarVida();
            // Reinicia la posición en X e Y de la imagen
            transform.position = new Vector3(posX, posY, transform.position.z + 70);
        }
    }

    void RestarVida()
    {
        vidas--; // Resta una vida
        Debug.Log("Vidas restantes: " + vidas);

        // Si deseas cambiar el estado del juego a "perdiste" cuando las vidas llegan a 0, puedes hacerlo aquí.
    }
}
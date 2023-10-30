using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Monstruo"))
        {
            Destroy(gameObject); // Destruye la imagen en lugar de reiniciar su posición
            //aca resta una vida
            HUD.Instance.DesactivarVida();
            GameManager.Instance.PerderVida();
        }

        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Saturno")) {
            SceneManager.LoadScene("Perdiste");
        }
    }
}
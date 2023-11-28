using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoSaturno : MonoBehaviour
{
    public float velocidadX = 2.0f; // Velocidad de movimiento en el eje X
    public float velocidadZ = 2.0f; // Velocidad de movimiento en el eje Z
    public float posY; // Posición en Y inicial
    public float limiteZ = -5.0f; // Límite en el eje Z
    public float limiteXMin = -2.0f; // Límite mínimo en el eje X
    public float limiteXMax = 2.0f; // Límite máximo en el eje X

    public bool _taMuerto = false;

    void Update()
    {
        if (_taMuerto) { return; }

        // Mueve la imagen automáticamente en los ejes X y Z
        float movimientoX = Mathf.PingPong(Time.time * velocidadX, limiteXMax - limiteXMin) + limiteXMin;
        float movimientoZ = velocidadZ * Time.deltaTime;
        transform.position = new Vector3(movimientoX, transform.position.y, transform.position.z - movimientoZ);

        // Verifica si la imagen llega al límite en Z
        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Monstruo"))
        {
            Destroy(gameObject); // Destruye la imagen en lugar de reiniciar su posición
            //aca resta una vida
            //HUD.Instance.DesactivarVida();
            GameManager.Instance.PerderVida();
            HUD.Instance.ActivarRasguño();
        }

        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Saturno"))
        {
            SceneManager.LoadScene("Perdiste");
            HUD.Instance.ActivarRasguño();
        }
    }
}

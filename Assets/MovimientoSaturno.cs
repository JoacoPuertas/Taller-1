using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoSaturno : MonoBehaviour
{
    public float velocidadX = 2.0f; // Velocidad de movimiento en el eje X
    public float velocidadZ = 2.0f; // Velocidad de movimiento en el eje Z
    public float posY; // Posici�n en Y inicial
    public float limiteZ = -5.0f; // L�mite en el eje Z
    public float limiteXMin = -2.0f; // L�mite m�nimo en el eje X
    public float limiteXMax = 2.0f; // L�mite m�ximo en el eje X

    public bool _taMuerto = false;

    void Update()
    {
        if (_taMuerto) { return; }

        // Mueve la imagen autom�ticamente en los ejes X y Z
        float movimientoX = Mathf.PingPong(Time.time * velocidadX, limiteXMax - limiteXMin) + limiteXMin;
        float movimientoZ = velocidadZ * Time.deltaTime;
        transform.position = new Vector3(movimientoX, transform.position.y, transform.position.z - movimientoZ);

        // Verifica si la imagen llega al l�mite en Z
        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Monstruo"))
        {
            Destroy(gameObject); // Destruye la imagen en lugar de reiniciar su posici�n
            //aca resta una vida
            //HUD.Instance.DesactivarVida();
            GameManager.Instance.PerderVida();
            HUD.Instance.ActivarRasgu�o();
        }

        if (transform.position.z < limiteZ && GameObject.FindGameObjectWithTag("Saturno"))
        {
            SceneManager.LoadScene("Perdiste");
            HUD.Instance.ActivarRasgu�o();
        }
    }
}

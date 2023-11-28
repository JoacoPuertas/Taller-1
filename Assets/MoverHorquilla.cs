using UnityEngine;

public class MoverHorquilla : MonoBehaviour
{
    private Vector3 posicionOriginal;
    private float duracionMovimiento = 0.25f;
    private float distanciaMovimiento = 1.0f;
    private float velocidadVuelta = 3.0f;
    private float tiempoInicioMovimiento;

    void Start()
    {
        posicionOriginal = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            IniciarMovimiento();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            IniciarMovimiento();
        }

        if (EsTiempoDeMover())
        {
            MoverHaciaAdelante();
        }
        else if (transform.position.z > posicionOriginal.z)
        {
            MoverHaciaAtras();
        }
    }

    bool EsTiempoDeMover()
    {
        return Time.time - tiempoInicioMovimiento < duracionMovimiento;
    }

    void MoverHaciaAdelante()
    {
        float porcentajeCompletado = (Time.time - tiempoInicioMovimiento) / duracionMovimiento;
        float distanciaActual = Mathf.Lerp(0, distanciaMovimiento, porcentajeCompletado);

        transform.position = posicionOriginal + new Vector3(0, 0, distanciaActual);
    }

    void MoverHaciaAtras()
    {
        float distanciaAtras = Mathf.Lerp(transform.position.z - posicionOriginal.z, 0, velocidadVuelta * Time.deltaTime);
        transform.position = new Vector3(posicionOriginal.x, posicionOriginal.y, posicionOriginal.z + distanciaAtras);
    }

    void IniciarMovimiento()
    {
        tiempoInicioMovimiento = Time.time;
    }
}

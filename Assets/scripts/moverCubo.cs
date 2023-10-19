using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverCubo : MonoBehaviour
{
    public float limiteZ = -20.0f;
    public float velocidad = 2.0f;

    void Update()
    {
        // Mueve el cubo en el eje Z restando velocidad * Time.deltaTime
        transform.Translate(Vector3.back * velocidad * Time.deltaTime);
    }
}
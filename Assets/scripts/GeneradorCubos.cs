using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorCubos : MonoBehaviour
{
    public GameObject prefabCubo;
    public Transform spawnPoint;
    public float tiempoEntreGeneraciones = 2.0f;

    private float tiempoDesdeLaUltimaGeneracion = 0;

    void Update()
    {
        tiempoDesdeLaUltimaGeneracion += Time.deltaTime;

        if (tiempoDesdeLaUltimaGeneracion >= tiempoEntreGeneraciones)
        {
            GenerarCubo();
            tiempoDesdeLaUltimaGeneracion = 0;
        }
    }

    void GenerarCubo()
    {
        Instantiate(prefabCubo, spawnPoint.position, Quaternion.identity);
    }
}
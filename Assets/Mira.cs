using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mira : MonoBehaviour
{
    public float distanciaMaxima = 100f; // Ajusta la distancia máxima a tu necesidad.

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Disparar();
        }
    }

    void Disparar()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit impacto;

        if (Physics.Raycast(rayo, out impacto, distanciaMaxima))
        {
            if (impacto.collider.CompareTag("Cubo")) 
            {
                Destroy(impacto.collider.gameObject);
                Debug.Log("aldasdlasldasd");
            }
        }
    }
}
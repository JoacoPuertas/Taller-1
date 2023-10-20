using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastExample : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica si se hizo clic con el botón izquierdo del mouse
        {
            DispararRaycast();
        }
    }

    void DispararRaycast()
    {
        Ray rayo = Camera.main.ScreenPointToRay(Input.mousePosition); // Dispara un rayo desde la posición del ratón
        RaycastHit impacto;

        if (Physics.Raycast(rayo, out impacto))
        {
            // El rayo colisionó con un objeto, puedes realizar acciones según la colisión.
            // Por ejemplo, puedes verificar la etiqueta del objeto colisionado:
            if (impacto.collider.CompareTag("Monstruo"))
            {
                // Hacer algo cuando se golpea un objeto con la etiqueta "Monstruo"
                Destroy(impacto.collider.gameObject); // Destruye el objeto colisionado
            }
        }
    }
}
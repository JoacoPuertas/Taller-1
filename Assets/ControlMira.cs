using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMira : MonoBehaviour
{
    public float velocidadMira = 5.0f;
    public Camera mainCamera;

    void Update()
    {
        // Obtener la posición del cursor del mouse en el mundo
        Vector3 posicionMouse = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.y - transform.position.z));
        posicionMouse.z = 0; // Asegurarse de que la mira esté en el mismo plano Z que la escena.

        // Mover la mira hacia la posición del cursor del mouse
        transform.position = Vector3.MoveTowards(transform.position, posicionMouse, velocidadMira * Time.deltaTime);
    }
}
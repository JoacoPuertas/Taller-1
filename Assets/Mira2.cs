using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Mira2 : MonoBehaviour
{
    private RectTransform rectTransform;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        // Obtén la posición del ratón en la ventana
        Vector2 mousePosition = Input.mousePosition;

        // Si se hace clic
        if (Input.GetMouseButtonDown(0))
        {
            // Comprueba si el ratón está sobre un elemento interactuable
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Si el ratón está sobre un objeto interactuable (como un botón), realiza la lógica correspondiente aquí
                Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (clickedButton != null)
                {
                    // Puedes activar el evento del botón aquí si es necesario
                    clickedButton.onClick.Invoke();
                }
            }
            else
            {
                // Si no está sobre un objeto interactuable, realiza tu lógica de clic fuera del botón aquí
            }
        }

        // Resto de tu lógica aquí
    }
}

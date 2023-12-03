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
        // Obt�n la posici�n del rat�n en la ventana
        Vector2 mousePosition = Input.mousePosition;

        // Si se hace clic
        if (Input.GetMouseButtonDown(0))
        {
            // Comprueba si el rat�n est� sobre un elemento interactuable
            if (EventSystem.current.IsPointerOverGameObject())
            {
                // Si el rat�n est� sobre un objeto interactuable (como un bot�n), realiza la l�gica correspondiente aqu�
                Button clickedButton = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
                if (clickedButton != null)
                {
                    // Puedes activar el evento del bot�n aqu� si es necesario
                    clickedButton.onClick.Invoke();
                }
            }
            else
            {
                // Si no est� sobre un objeto interactuable, realiza tu l�gica de clic fuera del bot�n aqu�
            }
        }

        // Resto de tu l�gica aqu�
    }
}

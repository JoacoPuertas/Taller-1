using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
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

        // Convierte la posici�n del rat�n de la ventana a la posici�n en el Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            mousePosition,
            null,
            out Vector2 localPoint
        );

        // Actualiza la posici�n de la imagen en el Canvas
        rectTransform.localPosition = localPoint;
    }
}

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
        // Obtén la posición del ratón en la ventana
        Vector2 mousePosition = Input.mousePosition;

        // Convierte la posición del ratón de la ventana a la posición en el Canvas
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            mousePosition,
            null,
            out Vector2 localPoint
        );

        // Actualiza la posición de la imagen en el Canvas
        rectTransform.localPosition = localPoint;
    }
}

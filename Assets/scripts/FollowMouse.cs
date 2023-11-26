using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    private RectTransform rectTransform;
    public GameObject flashPrefab;

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

        if (Input.GetKeyDown(KeyCode.P)) {
            Disparar();
        }
    }

    private void Disparar() {
        // Obtén el componente ParticleSystem del flashPrefab
        ParticleSystem particleSystem = flashPrefab.GetComponent<ParticleSystem>();

        // Reproduce el Particle System si está presente
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}

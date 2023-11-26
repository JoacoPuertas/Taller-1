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

        if (Input.GetKeyDown(KeyCode.P)) {
            Disparar();
        }
    }

    private void Disparar() {
        // Obt�n el componente ParticleSystem del flashPrefab
        ParticleSystem particleSystem = flashPrefab.GetComponent<ParticleSystem>();

        // Reproduce el Particle System si est� presente
        if (particleSystem != null)
        {
            particleSystem.Play();
        }
    }
}

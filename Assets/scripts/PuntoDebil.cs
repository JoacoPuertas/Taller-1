using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoDebil : MonoBehaviour
{
    private float time = 0;
    public GameObject Punto1;
    public GameObject Punto2;
    public GameObject Punto3;

    public float transparencia = 0f; // Define el valor de transparencia deseado (0 completamente transparente, 1 completamente opaco)

    void Update()
    {
        time += Time.deltaTime;

        if (time < 1)
        {
            CambiarTransparencia(Punto3, transparencia);
            CambiarTransparencia(Punto2, transparencia);
            CambiarTransparencia(Punto1, 1f);
        }
        else if (time >= 1 && time < 2)
        {
            CambiarTransparencia(Punto1, transparencia);
            CambiarTransparencia(Punto2, 1f);
        }
        else if (time >= 2 && time < 3)
        {
            CambiarTransparencia(Punto2, transparencia);
            CambiarTransparencia(Punto3, 1f);
        } else if ( time >= 4) {
            time = 0;
        }
    }

    void CambiarTransparencia(GameObject objeto, float alpha)
    {
        Renderer renderer = objeto.GetComponent<Renderer>();

        if (renderer != null)
        {
            Material material = renderer.material;
            Color color = material.color;
            color.a = alpha;
            material.color = color;
        }
        else
        {
            // Si estás trabajando con un SpriteRenderer en 2D, puedes hacerlo de la siguiente manera:
            SpriteRenderer spriteRenderer = objeto.GetComponent<SpriteRenderer>();

            if (spriteRenderer != null)
            {
                Color color = spriteRenderer.color;
                color.a = alpha;
                spriteRenderer.color = color;
            }
        }
    }
}
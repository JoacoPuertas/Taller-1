using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContadorVidas : MonoBehaviour
{
    public int vidas = 5; // Número inicial de vidas
    public Text textoVidas; // Arrastra el objeto Text del Canvas a este campo en el Inspector.

    void Start()
    {
        // Asigna el texto inicial.
        ActualizarContador();
    }

    // Llamada cuando necesitas actualizar el contador de vidas.
    public void ActualizarContador()
    {
        textoVidas.text = "Vidas: " + vidas;
    }

    // Llamada cuando se resta una vida.
    public void RestarVida()
    {
        vidas--;
        ActualizarContador(); // Llama a la función de actualización para reflejar el cambio en el Text.
    }
}
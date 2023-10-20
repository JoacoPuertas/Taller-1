using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public GameObject[] vidas;
    public void DesactivarVida(int indice) {
        vidas[indice].SetActive(false);
    }

    public void ActivasVida(int indice)
    {
        vidas[indice].SetActive(true);
    }
}

//using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }
    public List<GameObject> vidasGo;
    public List<GameObject> vidasSa;
    public GameObject rasguño;
    private void Awake()
    {
        Instance = this;
    }
    public void DesactivarVida(int vidas) {

        for (int i = 4; i >= vidas; i--)
        {
            vidasGo[i].SetActive(false);
        }

    }

    public void DesactivarVidaSaturno(int vidasSaturno)
    {
        for (int i = vidasSa.Count - 1; i >= 0; i--)
        {
            if (i >= vidasSaturno)
            {
                vidasSa[i].SetActive(false);
            }
        }
    }


    public void UpdateVidas(int vidas)
    {

        for (int i = 0; i < vidasGo.Count; i++)
        {
            if (i < vidas)
            {
                // Activar las vidas restantes
                if (!vidasGo[i].activeInHierarchy)
                    vidasGo[i].SetActive(true);
            }
            else
            {
                // Desactivar las vidas restantes
                if (vidasGo[i].activeInHierarchy)
                    vidasGo[i].SetActive(false);
            }
        }
    }

    public void ActivarVidas(int vidas)
    {
        //if (vidas >= 5) { return; }
        for (int i = 0; i < vidas; i++)
        {
            if (!vidasGo[i].activeInHierarchy)
                vidasGo[i].SetActive(true);
        }
    }

    public void ActivarRasguño() {
        rasguño.SetActive(true);
    }

}

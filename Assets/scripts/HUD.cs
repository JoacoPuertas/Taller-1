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

    public void UpdateVidas(int vidas)
    {

        for (int i = 5; i > vidas; i--)
        {
            Debug.Log(i-1);
            Debug.Log(vidasGo.Count);
            vidasGo[i-1].SetActive(false);
        }
    }

    public void ActivarVidas(int vidas)
    {
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;

public class HUD : MonoBehaviour
{
    public static HUD Instance { get; private set; }
    public List<GameObject> vidas;

    private void Awake()
    {
        Instance = this;
        //DontDestroyOnLoad(GameObject.FindWithTag("vidas"));
    }
    public void DesactivarVida() {
        if (vidas.Count == 1)
        {
            GameManager.Instance.ChangeActualScene(GameState.Perder);
            return;
        }
        vidas[vidas.Count-1].SetActive(false);
        vidas.RemoveAt(vidas.Count-1);
        
        
    }

    public void UpdateVidas(int vidasToDelete)
    {
        for (int i = vidas.Count; i > vidasToDelete; i--) 
        {
            vidas[vidas.Count - 1].SetActive(false);
            vidas.RemoveAt(vidas.Count - 1);
        }
    }

    public void ActivasVida(int indice)
    {
        vidas[indice].SetActive(true);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntoDebil : MonoBehaviour
{

    [SerializeField] private bool isTerrestre;
    [SerializeField] private KeyCode Tecla;


    private void Update()
    {
        if (isTerrestre)
        {
            if (Input.GetKeyDown(Tecla))
            {
                AvisarASAturno();
            }
        }
    }
    private void OnMouseOver()
    {
        if (isTerrestre) { return; }
        if (Input.GetMouseButtonDown(0))
        {
            AvisarASAturno();
        }

    }

    private void AvisarASAturno()
    {
        gameObject.GetComponentInParent<SaturnoComportamiento>().MePegaron();
    }
}

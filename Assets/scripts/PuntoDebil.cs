using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuntoDebil : MonoBehaviour
{

    [SerializeField] private bool OnlyParent;
    [SerializeField] private bool Ultimo;
    [SerializeField] private bool isTerrestre;
    [SerializeField] private KeyCode Tecla;
    [SerializeField] private KeyCode TeclaDisparo;


    private void Update()
    {
        if (OnlyParent) { return; }
        if (isTerrestre)
        {
            if (Input.GetKeyDown(Tecla))
            {
                AvisarASAturno();
            }
        }

        if (Ultimo) {
            AvisarASAturno();
        }
    }
    private void OnMouseOver()
    {
        if (OnlyParent) { return; }
        if (isTerrestre) { return; }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            AvisarASAturno();
        }

    }

    private void AvisarASAturno()
    {
        Debug.Log("AvisarASAturno llamado");
        gameObject.GetComponentInParent<SaturnoComportamiento>().MePegaron();
    }
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaturnoComportamiento : MonoBehaviour
{
    [SerializeField] private GameObject[] _puntosDebiles;
    private int _puntosDebilesCount=0;




    public void MePegaron()
    {
        //bajar barrita
        GameManager.Instance.PerderVidaSaturno();
        if (_puntosDebilesCount == _puntosDebiles.Length - 1)
        {
            Debug.Log("Cargando la escena Ganaste");
            SceneManager.LoadScene("Ganaste");
            return;
        }

        _puntosDebiles[_puntosDebilesCount].SetActive(false);
        _puntosDebilesCount++;

        if (_puntosDebilesCount < _puntosDebiles.Length)
        {
            _puntosDebiles[_puntosDebilesCount].SetActive(true);
        }
    }



}

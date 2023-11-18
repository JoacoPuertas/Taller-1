using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SaturnoComportamiento : MonoBehaviour
{
    [SerializeField] private GameObject[] _puntosDebiles;
    private int _puntosDebilesCount=0;



    public void MePegaron()
    {
        if(_puntosDebilesCount >= _puntosDebiles.Length)
        {
            Destroy(gameObject);
        }

        _puntosDebiles[_puntosDebilesCount].SetActive(false);
        _puntosDebilesCount++;
        _puntosDebiles[_puntosDebilesCount].SetActive(true);
    }


}

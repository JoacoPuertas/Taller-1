using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaturnoComportamiento : MonoBehaviour
{
    [SerializeField] private GameObject[] _puntosDebiles;
    private int _puntosDebilesCount=0;
    private Animator animator;
    [SerializeField] private MoverImagen2D _moverImagen;


    void Start()
    {
        if (!gameObject.TryGetComponent<Animator>(out var anim))
        {
            Debug.LogWarning("NO TENGO ANIMATOR");
            return;
        }
        animator = anim;
    }

    public void MePegaron()
    {
        //bajar barrita
        GameManager.Instance.PerderVidaSaturno();
        if (_puntosDebilesCount == _puntosDebiles.Length - 1)
        {
            _puntosDebiles[_puntosDebilesCount].SetActive(false);
            Debug.Log("Cargando la escena Ganaste");
            //SceneManager.LoadScene("Ganaste");
            DestruirEsteMonstruo();
            return;
        }

        _puntosDebiles[_puntosDebilesCount].SetActive(false);
        _puntosDebilesCount++;

        if (_puntosDebilesCount < _puntosDebiles.Length)
        {
            _puntosDebiles[_puntosDebilesCount].SetActive(true);
        }
    }

    private void DestruirEsteMonstruo()
    {
        if (animator != null)
        {
            animator.SetBool("Muerto", true);
            _moverImagen._taMuerto = true;
            return;
        }
        DestruirMostro();

        //_moverImagen.enabled = false;
    }

    public void DestruirMostro()
    {
        Destroy(gameObject);
    }

    public void DestruirSaturno()
    {
        Destroy(gameObject);
        SceneManager.LoadScene("Ganaste");
    }



}

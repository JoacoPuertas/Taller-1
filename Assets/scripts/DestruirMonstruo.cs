using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestruirMonstruo : MonoBehaviour

{
    [SerializeField] private KeyCode Tecla;
    [SerializeField] private KeyCode TeclaDisparo;
    [SerializeField] private float SaturnoVidas = 20;
    private Animator animator;
    [SerializeField] private MoverImagen2D _moverImagen;

    void Start()
    {
        if(!gameObject.TryGetComponent<Animator>(out var anim))
        {
            Debug.LogWarning("NO TENGO ANIMATOR");
            return;
        }
        animator = anim;
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Tecla) && transform.position.z < 5 && SceneManager.GetActiveScene().name == "level1" 
            || Input.GetKeyDown(Tecla) && transform.position.z < 5 && SceneManager.GetActiveScene().name == "Level2")
        {
            //animator.SetBool("muerto", true);
            DestruirEsteMonstruo();
        }
        if (SceneManager.GetActiveScene().name == "Level3" && Input.GetKeyDown(Tecla)) 
        {
            SaturnoVidas--;
            if (SaturnoVidas <= 0)
            {
                SceneManager.LoadScene("Ganaste");
                DestruirEsteMonstruo();
            }
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(TeclaDisparo) && SceneManager.GetActiveScene().name == "level1"
            || Input.GetKeyDown(TeclaDisparo) && SceneManager.GetActiveScene().name == "Level2") // Verifica si se hizo clic con el botón izquierdo del mouse
        {
            //animator.SetBool("Muerto", true);
            DestruirEsteMonstruo();
        }

        if (SceneManager.GetActiveScene().name == "Level3" && Input.GetKeyDown(TeclaDisparo))
        {
            SaturnoVidas--;
            if (SaturnoVidas <= 0)
            {
                SceneManager.LoadScene("Ganaste");
                DestruirEsteMonstruo();
                SceneManager.LoadScene("Ganaste");
                Debug.Log("Mataste a saturno");

            }
        }

    }
    private void DestruirEsteMonstruo()
    {
        if (animator != null)
        {
            animator.SetBool("Muerto",true);
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
    
}
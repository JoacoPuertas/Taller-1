using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestruirMonstruo : MonoBehaviour

{
    [SerializeField] private KeyCode Tecla;
    [SerializeField] private float SaturnoVidas = 20;
    //private Animator animator;
    void Start()
    {
        //animator = GetComponent<Animator>();
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
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "level1"
            || Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "Level2") // Verifica si se hizo clic con el botón izquierdo del mouse
        {
            //animator.SetBool("Muerto", true);
            DestruirEsteMonstruo();
        }

        if (SceneManager.GetActiveScene().name == "Level3" && Input.GetMouseButtonDown(0))
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
        //animator.SetBool("muerto",true);
        //Debug.Log(animator);
        Destroy(gameObject); // Destruye el monstruo actual
    }

    
}
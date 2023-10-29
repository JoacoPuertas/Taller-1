using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestruirMonstruo : MonoBehaviour

{
    [SerializeField] private KeyCode Tecla;
    [SerializeField] private float SaturnoVidas = 20;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Tecla) && transform.position.z < 10 && SceneManager.GetActiveScene().name == "level1" 
            || Input.GetKeyDown(Tecla) && transform.position.z < 10 && SceneManager.GetActiveScene().name == "Level2")
        {
            DestruirEsteMonstruo();
        }
        if (SceneManager.GetActiveScene().name == "Level3" && Input.GetKeyDown(Tecla)) 
        {
            SaturnoVidas--;
            if (SaturnoVidas <= 0)
            {
                DestruirEsteMonstruo();
            }
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "level1"
            || Input.GetMouseButtonDown(0) && SceneManager.GetActiveScene().name == "Level2") // Verifica si se hizo clic con el botón izquierdo del mouse
        {
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

            }
        }

    }
    private void DestruirEsteMonstruo()
    {
        Destroy(gameObject); // Destruye el monstruo actual
    }

    
}
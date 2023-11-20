using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CorazonBehavior : MonoBehaviour
{

    [SerializeField] private KeyCode TeclaDisparo;


    //poner aca que va a hacer el corazon
    private void Start()
    {
        // Establecer la posición aleatoria al inicio
        GenerarPosicionAleatoria();
    }

    private void OnMouseOver()
    {
        Debug.Log("Le pegué al bonus");
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Le pegué al bonus con el mouse ");
        }
        if ( Input.GetKeyDown(TeclaDisparo)) // Verifica si se hizo clic con el botón izquierdo del mouse
        {
            //animator.SetBool("Muerto", true);
            Debug.Log("Tecla presionada: " + TeclaDisparo.ToString());
            SumarVida2();
            Debug.Log("Le pegué al bonus");
        }

    }


    //cuando el corazon muera
    private void SumarVida2()
    {
        Debug.Log("cande pelotuda");
        GameManager.Instance.SumarVida();
        Destroy(gameObject);
    }

    private void GenerarPosicionAleatoria()
    {
        // Generar una posición aleatoria en el eje X entre -2f y 2f, y mantener y = 1f y z = 5f.
        Vector3 nuevaPosicion = new Vector3(Random.Range(-2f, 2f), Random.Range(1f, 3f), 5f);
        transform.position = nuevaPosicion; // Establecer la nueva posición.
    }
}

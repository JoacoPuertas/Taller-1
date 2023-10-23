using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirConZona : MonoBehaviour
{

    //Variable que usamos para determinar a que Letra responde.
    public KeyCode tecla;
    //Booleana que nos dice si esta pasando una nota por el collider del activador.
    bool activo = false;
    //Llamamos a las notas
    public GameObject Monstruo;
    //Creamos una variable gameObject para poder llamar a gameManager
    public GameObject gm;

    void Start()
    {
        //Llamamos a nuestro Game Manager, para poder usar sus funciones
        gm = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    { 
            //Si apretamos la tecla del activador y activo es verdadero ( ya que esta pasando una nota )
            if (Input.GetKeyDown(tecla) && activo)
            {
                Destroy(Monstruo); //Destruimos esa nota
                activo = false;
            }
        }

    void OnTriggerExit(Collider col)
    {
        activo = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Monstruo")
        {
            activo = true;
            Monstruo = col.gameObject;
        }
    }

}

    


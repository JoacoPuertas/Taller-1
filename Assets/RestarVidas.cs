using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestarVidas : MonoBehaviour
{
    public int vidas = 5;

    // Actualiza el controlador
    void Update()
    {
        GameObject[] cubos = GameObject.FindGameObjectsWithTag("Cubo");

        foreach (GameObject cubo in cubos)
        {
            if (cubo.transform.position.z < -10)
            {
                RestarVida();
                Destroy(cubo);
            }
        }
    }

     void RestarVida()
    {
        vidas--;
        Debug.Log("Vidas: " + vidas);

        // Si las vidas llegan a 0, aquí puedes cambiar el estado del juego a "perdiste".
    }
}
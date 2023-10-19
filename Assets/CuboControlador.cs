using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuboControlador : MonoBehaviour
{
    public int vidas = 5;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.position.z <= -8)
        {
            RestarVida();
        }
    }

    void RestarVida()
    {
        vidas -= 1;
        Debug.Log("Vidas: " + vidas);
    }
}
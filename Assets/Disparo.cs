using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Cubo"))
        {
            Destroy(other.gameObject); // Destruye el cubo
            Debug.Log("choque");
        }
    }
}

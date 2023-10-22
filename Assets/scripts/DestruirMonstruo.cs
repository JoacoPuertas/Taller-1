using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirMonstruo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0)) // Verifica si se hizo clic con el botón izquierdo del mouse
        {
            DestruirEsteMonstruo();
        }
    }
    private void DestruirEsteMonstruo()
    {
        Destroy(gameObject); // Destruye el monstruo actual
    }
}
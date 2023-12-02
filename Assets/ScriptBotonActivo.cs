using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptBotonActivo : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject _Pantalla;
    public GameObject _Boton;
    private float timer = 2;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Pantalla.activeSelf) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                _Boton.SetActive(true);
            }
        }
    }
}

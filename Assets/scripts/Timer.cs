using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _Spawn;
    public float timer = 20;
    public Text textoTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Spawn.active)
        {
            timer -= Time.deltaTime;
        }
        textoTimer.text = "Tiempo: " + timer.ToString("f0");
        if (timer < 0) {

            timer = 20;

        }
    }
}

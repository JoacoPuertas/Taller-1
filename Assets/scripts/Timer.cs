using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _Spawn;
    [SerializeField] private GameObject _Oleada2;
    public float timer = 20;
    public Text textoTimer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_Spawn.activeSelf || _Oleada2.activeSelf)
        {
            timer -= Time.deltaTime;
        }
        textoTimer.text = "Tiempo: " + timer.ToString("f0");
        if (timer < 0 && _Spawn.activeSelf) {

            _Spawn.SetActive(false);
            _Oleada2.SetActive(true);
            timer = 2;
        }
        if (timer < 0 && _Oleada2.activeSelf)
        {

            _Spawn.SetActive(true);
            _Oleada2.SetActive(false);
            timer = 20;
        }
    }
}

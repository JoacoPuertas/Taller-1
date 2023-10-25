using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _Spawn;
    [SerializeField] private GameObject _Oleada2;
    public float timer = 20;
    public Text textoTimer;
    public float OleadaTimer = 3;
    bool oleada2Started = false;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level1")
        {
            // Activa _Spawn al inicio en la escena "Level1".
            _Spawn.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            // Desactiva _Spawn al inicio en la escena "Level2".
            _Spawn.SetActive(false);
        }
    }

    void Update()
    {
        if (_Spawn.activeSelf)
        {
            timer -= Time.deltaTime;

            if (timer < 0 && SceneManager.GetActiveScene().name == "Level1")
            {
                SceneManager.LoadScene("Level2");
                // Reinicia el temporizador y marca que la oleada 2 ha comenzado.
                timer = 20;
                oleada2Started = true;
            }
        }

        // Solo disminuye OleadaTimer si estás en la escena "Level2" y no ha comenzado.
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            {
                OleadaTimer -= Time.deltaTime;
                if (OleadaTimer <= 0)
                {
                    // Desactiva _Oleada2 y activa _Spawn cuando OleadaTimer llega a 0.
                    _Oleada2.SetActive(false);
                    _Spawn.SetActive(true);
                }
            }

            textoTimer.text = "Tiempo: " + timer.ToString("f0");
        }
    }
}
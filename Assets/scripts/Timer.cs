using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _Spawn;
    [SerializeField] private GameObject _Oleada2;
    [SerializeField] private GameObject _Saturno;
    public float timer = 20;
    public Text textoTimer;
    public float OleadaTimer = 3;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "level1")
        {
            // Activa _Spawn al inicio en la escena "Level1".
            _Spawn.SetActive(true);
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            // Desactiva _Spawn al inicio en la escena "Level2".
            _Spawn.SetActive(false);
        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            // Desactiva _Spawn al inicio en la escena "Level3".
            _Spawn.SetActive(false);
        }

    }

    void Update()
    {
        if (_Spawn.activeSelf || _Saturno.activeSelf)
        {
            timer -= Time.deltaTime;
            textoTimer.text = "Tiempo: " + timer.ToString("f0");
            if (timer < 0 && SceneManager.GetActiveScene().name == "level1")
            {
                SceneManager.LoadScene("Level2");
                // Reinicia el temporizador
                timer = 20;
            }
            if (timer < 0 && SceneManager.GetActiveScene().name == "Level2")
            {
                SceneManager.LoadScene("Level3");
                // Reinicia el temporizador
                timer = 20;
            }
            if (timer < 0 && SceneManager.GetActiveScene().name == "Level3")
            {
                SceneManager.LoadScene("Ganaste");
                timer = 20;
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
                    OleadaTimer = 3;
                }
            }

        }
        else if (SceneManager.GetActiveScene().name == "Level3")
        {
            {
                OleadaTimer -= Time.deltaTime;
                if (OleadaTimer <= 0)
                {
                    // Desactiva _Oleada2 y activa _Spawn cuando OleadaTimer llega a 0.
                    _Oleada2.SetActive(false);
                    _Saturno.SetActive(true);
                    OleadaTimer = 3;
                }
            }

        }
    }
}
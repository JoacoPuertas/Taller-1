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
    public float CinematicaTimer = 20;

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
            if (timer > 0) {
                timer -= Time.deltaTime;
            }
            textoTimer.text =timer.ToString("f2");
            if (timer < 0 && SceneManager.GetActiveScene().name == "level1" && !HasMonstruo())
            {
                SceneManager.LoadScene("Level2");
                // Reinicia el temporizador
                timer = 20;
            }
            if (timer < 0 && SceneManager.GetActiveScene().name == "Level2" && !HasMonstruo())
            {
                SceneManager.LoadScene("Level3");
                // Reinicia el temporizador
                timer = 20;
            }
            if (timer < 0 && SceneManager.GetActiveScene().name == "Level3" && !HasMonstruo())
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
                }
            }

        }
        else if (SceneManager.GetActiveScene().name == "Cinematicas")
        {
            {
                CinematicaTimer -= Time.deltaTime;
                if (CinematicaTimer <= 0)
                {
                    SceneManager.LoadScene("level1");
                }
            }

        }
    }
    private bool HasMonstruo()
    {
        GameObject[] monstruos = GameObject.FindGameObjectsWithTag("Monstruo");
        return monstruos.Length > 0;
    }
}
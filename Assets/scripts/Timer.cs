using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _Spawn;
    [SerializeField] private GameObject _Oleada2;
    [SerializeField] private GameObject _Saturno;
    [SerializeField] private GameObject _corazoncito;
    [SerializeField] private GameObject _Portal;
    public float timer = 20;
    public Text textoTimer;
    public Text textoTimerOleada;
    public float OleadaTimer = 3;
    public float CinematicaTimer = 15;
    private bool _heartSpawned = true;
    private bool Listo = true;

    private string estaEscena;

    void Start()
    {
        if (estaEscena == "level1")
        {
            // Activa _Spawn al inicio en la escena "Level1".
            _Spawn.SetActive(false);
        }
        else if (estaEscena == "Level2")
        {
            // Desactiva _Spawn al inicio en la escena "Level2".
            _Spawn.SetActive(false);
        }
        else if (estaEscena == "Level3")
        {
            // Desactiva _Spawn al inicio en la escena "Level3".
            _Spawn.SetActive(false);
        }

        estaEscena = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if (_Spawn.activeSelf || _Saturno.activeSelf)
        {
            if (timer > 0) {
                timer -= Time.deltaTime;
            }
            textoTimer.text =timer.ToString("f0");
            if (timer < 0 && estaEscena == "level1" && !HasMonstruo())
            {
                SceneManager.LoadScene("Level2");
                // Reinicia el temporizador
                timer = 20;
            }

            if (timer < 15 && _heartSpawned && estaEscena == "Level2")
            {
                //Instantiate(_corazoncito);
                _corazoncito.SetActive(true);
                _heartSpawned = false;
            }


            if (timer < 0 && estaEscena == "Level2" && !HasMonstruo())
            {
                SceneManager.LoadScene("Level3");
                // Reinicia el temporizador
                timer = 20;
            }
            if (timer < 0 && estaEscena == "Level3" && !HasMonstruo())
            {
                //SceneManager.LoadScene("Ganaste");
                timer = 20;
            }
        }

        // Solo disminuye OleadaTimer si estás en la escena "Level2" y no ha comenzado.
        if (estaEscena == "level1")
        {
            {
                OleadaTimer -= Time.deltaTime;
                textoTimerOleada.text = OleadaTimer.ToString("f0");
                if (OleadaTimer <= 0)
                {
                    // Desactiva _Oleada2 y activa _Spawn cuando OleadaTimer llega a 0.
                    _Oleada2.SetActive(false);
                    _Spawn.SetActive(true);
                }

            }

        }
        else if (estaEscena == "Level2")
        {
            {
                OleadaTimer -= Time.deltaTime;
                textoTimerOleada.text = OleadaTimer.ToString("f0");
                if (OleadaTimer <= 0)
                {
                    // Desactiva _Oleada2 y activa _Spawn cuando OleadaTimer llega a 0.
                    _Oleada2.SetActive(false);
                    _Spawn.SetActive(true);
                }
                
            }

        }
        else if (estaEscena == "Level3")
        {
            {
                OleadaTimer -= Time.deltaTime;
                textoTimerOleada.text = OleadaTimer.ToString("f0");
                if (OleadaTimer <= 0)
                {
                    // Desactiva _Oleada2 y activa _Spawn cuando OleadaTimer llega a 0.
                    _Oleada2.SetActive(false);
                    _Saturno.SetActive(true);
                }
                if (OleadaTimer <= 0 && Listo == true)
                {
                    _Portal.SetActive(true);
                    Listo = false;
                }
            }

        }
        else if (estaEscena == "Cinematicas")
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

    public void ApagarPortal() {
        _Portal.SetActive(false);
    }
}
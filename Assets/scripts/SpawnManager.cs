using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    [Serializable]
    public struct Mostros
    {
        public GameObject Mostro;
        public int Velocidad;
    }

    [Header("Nivel1")]
    [SerializeField]
    public List<Mostros> TodosLoMostrosTerrestres1 = new List<Mostros>();
    [SerializeField]
    public List<Mostros> TodosLoMostrosAereos1 = new List<Mostros>();
    [SerializeField, Range(0, 10)]
    private float tiempoDeSpawn1 = 5;
    private float TiempoDeSpawn2 = 20;

    private float actualTime;

    private void Update()
    {
        if (TiempoDeSpawn2 < 4 && SceneManager.GetActiveScene().name == "level1" && !HasMonstruo()) {
            SceneManager.LoadScene("Level2");        
        }
        if (TiempoDeSpawn2 < 4 && SceneManager.GetActiveScene().name == "level2" && !HasMonstruo())
        {
            SceneManager.LoadScene("Level3");
        }
        TiempoDeSpawn2 -= Time.deltaTime;
        if (TiempoDeSpawn2 > 4) 
        {
            actualTime += Time.deltaTime;
            if (actualTime > tiempoDeSpawn1)
            {
                int terrestreRandom = UnityEngine.Random.Range(0, TodosLoMostrosTerrestres1.Count);
                int aereoRandom = UnityEngine.Random.Range(0, TodosLoMostrosAereos1.Count);

                float posicionTerrestreRandom = UnityEngine.Random.Range(-2.75f, 2.75f);
                float posicionAereoRandom = UnityEngine.Random.Range(-2.75f, 2.75f);

                Vector3 posTerrestre = new Vector3(posicionTerrestreRandom, 0.5f, transform.position.z);
                Vector3 posAereo = new Vector3(posicionAereoRandom, 0.5f + 4f, transform.position.z);

                GameObject terrestreSpawned = Instantiate(TodosLoMostrosTerrestres1[terrestreRandom].Mostro, posTerrestre, Quaternion.identity);
                GameObject aereoSpawned = Instantiate(TodosLoMostrosAereos1[aereoRandom].Mostro, posAereo, Quaternion.identity);

                terrestreSpawned.GetComponent<MoverImagen2D>().velocidad = TodosLoMostrosTerrestres1[terrestreRandom].Velocidad;
                aereoSpawned.GetComponent<MoverImagen2D>().velocidad = TodosLoMostrosAereos1[aereoRandom].Velocidad;

                actualTime = 0;
            }
        }
        
    }

    private bool HasMonstruo()
    {
        GameObject[] monstruos = GameObject.FindGameObjectsWithTag("Monstruo");
        return monstruos.Length > 0;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        TiempoDeSpawn2 -= Time.deltaTime;
        if (TiempoDeSpawn2 > 4) 
        { 
            actualTime += Time.deltaTime;
            if (actualTime > tiempoDeSpawn1)
            {
                int terrestreRandom = UnityEngine.Random.Range(0, TodosLoMostrosTerrestres1.Count);
                int aereoRandom = UnityEngine.Random.Range(0, TodosLoMostrosAereos1.Count);

                float posicionTerrestreRandom = UnityEngine.Random.Range(-4f, 4f);
                float posicionAereoRandom = UnityEngine.Random.Range(-4f, 4f);

                Vector3 posTerrestre = new Vector3(posicionTerrestreRandom, transform.position.y, transform.position.z);
                Vector3 posAereo = new Vector3(posicionAereoRandom, transform.position.y + 5f, transform.position.z);

                GameObject terrestreSpawned = Instantiate(TodosLoMostrosTerrestres1[terrestreRandom].Mostro, posTerrestre, Quaternion.identity);
                GameObject aereoSpawned = Instantiate(TodosLoMostrosAereos1[aereoRandom].Mostro, posAereo, Quaternion.identity);

                terrestreSpawned.GetComponent<MoverImagen2D>().velocidad = TodosLoMostrosTerrestres1[terrestreRandom].Velocidad;
                aereoSpawned.GetComponent<MoverImagen2D>().velocidad = TodosLoMostrosAereos1[aereoRandom].Velocidad;

                actualTime = 0;
            }
        }
        
    }
}

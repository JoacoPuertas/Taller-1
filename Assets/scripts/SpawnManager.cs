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


    [Space]
    [Header("Nivel2")]

    [SerializeField]
    public List<Mostros> TodosLoMostros2 = new List<Mostros>();
    [Space]
    [Header("Nivel3")]
    [SerializeField]
    public List<Mostros> TodosLoMostros3 = new List<Mostros>();


    private float actualTime;
    private void Update()
    {
        actualTime += Time.deltaTime;
        if (actualTime > tiempoDeSpawn1)
        {
            int mostroRandom = UnityEngine.Random.Range(0, TodosLoMostrosTerrestres1.Count);

            float posicionRandom = UnityEngine.Random.Range(-4f, 4f);

            Vector3 actualPos = new Vector3(posicionRandom, transform.position.y, transform.position.z);

            GameObject MostroEspawneado = Instantiate(TodosLoMostrosTerrestres1[mostroRandom].Mostro,
                                                        actualPos,
                                                        Quaternion.identity);
            MostroEspawneado.GetComponent<MoverImagen2D>().velocidad = TodosLoMostrosTerrestres1[mostroRandom].Velocidad;
            actualTime = 0;
        }
    }

}

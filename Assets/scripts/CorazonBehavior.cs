using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CorazonBehavior : MonoBehaviour
{

    private int vidas = 1;


    //poner aca que va a hacer el corazon




    //cuando el corazon muera
    private void SumarVida()
    {
        GameManager.Instance.SumarVida();
        Destroy(gameObject);
    }
}

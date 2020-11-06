using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiempoSonido : MonoBehaviour
{

    public float tiempoDeVida = 1;
    void Start()
    {
        Destroy(gameObject, tiempoDeVida);
    }

}

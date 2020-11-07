using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidosMuerte : MonoBehaviour
{
    public GameObject[] sonidosAleatorios;
    float counter = 30;
    void Start()
    {
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        int res = Random.Range(0, sonidosAleatorios.Length);
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            Instantiate(sonidosAleatorios[res]);
            counter = 30;
        }
    }
}

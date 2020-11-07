using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonidoManager : MonoBehaviour
{
    public GameObject[] sonidosInicio;
    public GameObject[] sonidosAleatorios;

    bool start = true;
    float counter = 30;
    void Start()
    {
        start = true;
        counter = 4;
        Instantiate(sonidosInicio[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(start && counter <= 0)
        {
            Instantiate(sonidosInicio[1]);
            start = false;
            counter = 30;
        }
        
        int res = Random.Range(0, sonidosAleatorios.Length);
        counter -= Time.deltaTime;
        if (counter <= 0 && !start)
        {
            Instantiate(sonidosAleatorios[res]);
            counter = 30;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cuantoTiempo = 5f;
    public GameObject obstacle;

    float timer;
    void Start()
    {
        
    }

    void Update()
    {
        timer -= Time.deltaTime;

        if(timer <= 0)
        {
            GenerarObstaculo();
        }
    }

    void GenerarObstaculo()
    {
        int posicion = Random.Range(-1, 2);

        Vector3 nuevaPosicion = new Vector3(transform.position.x, (posicion * 3.5f) + 0.5f, transform.position.z);

        Instantiate(obstacle, nuevaPosicion, transform.rotation);
        timer = cuantoTiempo;
    }
}

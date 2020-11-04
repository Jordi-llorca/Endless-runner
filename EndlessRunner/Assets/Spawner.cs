using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float cuantoTiempo = 5f;
    public GameObject obstacleMadera;
    public GameObject obstacleHierro;
    public GameObject quesoCompleto;
    

    float timerSpawn;
    public float timerPrimerSpawnHierro = 30f;
    int counter = 5;

    static public float velocidadObjetos = 2f;

    void Update()
    {
        velocidadObjetos += Time.deltaTime * 0.05f;
        timerSpawn -= Time.deltaTime;
        timerPrimerSpawnHierro -= Time.deltaTime;

        if (timerSpawn <= 0)
        {   
            if (timerPrimerSpawnHierro > 0)
            {
                GenerarObstaculo(obstacleMadera);
            }   
            else
            {
                if (counter > 0)
                {
                    GenerarObstaculo(obstacleMadera);
                    counter--;
                }
                else
                {
                    int res = Random.Range(0, 2);
                    if (res == 0) GenerarObstaculo(obstacleHierro);
                    else GenerarObstaculo(quesoCompleto);
                    counter = Random.Range(1, 5);
                }
            }
        }
    }

    void GenerarObstaculo(GameObject obstacle)
    {
        int posicion = Random.Range(-1, 2);

        Vector3 nuevaPosicion = new Vector3(transform.position.x, (posicion * 3.5f) + 0.5f, transform.position.z);

        Instantiate(obstacle, nuevaPosicion, transform.rotation);
        timerSpawn = cuantoTiempo;
        cuantoTiempo = cuantoTiempo < 0.5f ? cuantoTiempo : cuantoTiempo - 0.005f;
    }
}

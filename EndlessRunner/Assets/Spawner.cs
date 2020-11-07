using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject obstacleMadera;
    public GameObject obstacleHierro;
    public GameObject quesito;
    public GameObject quesoCompleto;
    public float velocidadInicial = 2f;
    public float timerPrimerSpawnHierro = 30f;

    float timerSpawn;
    int counter = 5;
    int posPrev;

    static public float velocidadObjetos;
    static public int objetosEnPantalla = 0;
    static public bool spawnear = false;
    void Start()
    {
        timerPrimerSpawnHierro = 30f;
        velocidadObjetos = velocidadInicial;
        counter = 5;
        objetosEnPantalla = 0;
    }
    void Update()
    {
        velocidadObjetos += Time.deltaTime * 0.05f;
        timerSpawn -= Time.deltaTime;
        timerPrimerSpawnHierro -= Time.deltaTime;

        if ((timerSpawn <= 0 || (spawnear && velocidadObjetos > 3)) && objetosEnPantalla < 4)
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
                    else
                    {
                        res = Random.Range(0, 2);
                        if(PlayerMovement.vHearts < 2 && res == 0)
                            GenerarObstaculo(quesito);
                        else
                            GenerarObstaculo(quesoCompleto);
                    }
                    counter = Random.Range(1, 5);
                }
            }
        }
    }

    void GenerarObstaculo(GameObject obstacle)
    {
        int posicion = Random.Range(-1, 2);
        while (posicion == posPrev) posicion = Random.Range(-1, 2);
        Vector3 nuevaPosicion = new Vector3(transform.position.x, (posicion * 3.5f) + 0.5f, transform.position.z);

        posPrev = posicion;
        Instantiate(obstacle, nuevaPosicion, transform.rotation);
        spawnear = false;
        objetosEnPantalla++;
        timerSpawn = 1.5f;
    }
}

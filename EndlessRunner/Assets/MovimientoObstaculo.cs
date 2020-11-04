using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    float velocidad;
    private void Start()
    {
        velocidad = Spawner.velocidadObjetos;
    }
    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
        if(transform.position.x <= -12)
        {
            Destroy(this.gameObject);
            Spawner.spawnear = true;
            Spawner.objetosEnPantalla--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        Spawner.spawnear = true;
        Spawner.objetosEnPantalla--;
    }
}

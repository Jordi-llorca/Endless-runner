using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQueso : MonoBehaviour
{
    float velocidad;
    float timer;
    public float movVert = 2f;
    

    private void Start()
    {
        velocidad = Spawner.velocidadObjetos;
    }
    void Update()
    {
        transform.Translate(new Vector3(-velocidad * Time.deltaTime, movVert));
        if (timer < 1) { movVert *= -1; timer = 1.5f; }
        timer -= Time.deltaTime;
        if (transform.position.x <= -12)
        {
            Destroy(this.gameObject);
            Spawner.spawnear = true;
            Spawner.objetosEnPantalla--;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement.lscore++;
        Destroy(this.gameObject);
        Spawner.spawnear = true;
        Spawner.objetosEnPantalla--;
        if(PlayerMovement.lscore >= 2)
        {
            if(PlayerMovement.vHearts < 2) PlayerMovement.vHearts++;
            PlayerMovement.lscore = 0;
        }
    }
}

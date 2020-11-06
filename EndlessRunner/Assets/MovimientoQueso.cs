using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQueso : MonoBehaviour
{
    float velocidad;
    float timer;
    public float movVert = 2f;

    public GameObject comerQueso;
    public GameObject vidaExtra;
    public GameObject vidaExtra2;
    public GameObject nyam;
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
        Instantiate(comerQueso);
        Transform pos = this.GetComponent<Transform>();
        Vector3 res = new Vector3(pos.position.x, pos.position.y);
        Instantiate(nyam, res, pos.rotation);
        if (PlayerMovement.lscore >= 2)
        {
            if (PlayerMovement.vHearts < 2)
            {
                PlayerMovement.vHearts++;
                if (PlayerMovement.vHearts == 1) Instantiate(vidaExtra);
                else if (PlayerMovement.vHearts == 2) Instantiate(vidaExtra2);
            }
            PlayerMovement.lscore = 0;
        }
    }
}

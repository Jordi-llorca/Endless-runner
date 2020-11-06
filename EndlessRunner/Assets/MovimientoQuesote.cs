using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoQuesote : MonoBehaviour
{
    float velocidad;
    float timer;
    public float movVert = 2f;

    public GameObject comerQueso;
    public GameObject nyam;
    void Start()
    {
        velocidad = Spawner.velocidadObjetos;
    }

    // Update is called once per frame
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
        Transform pos = this.GetComponent<Transform>();
        Vector3 res = new Vector3(pos.position.x, pos.position.y);
        Instantiate(nyam, res, pos.rotation);
        Score.scoreValue += (int) (Score.scoreValue * 0.10f);
        Destroy(this.gameObject);
        Spawner.spawnear = true;
        Spawner.objetosEnPantalla--;
        Instantiate(comerQueso);

    }
}

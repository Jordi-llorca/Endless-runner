using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int position = 0;
    public float distancia = 3f;
    public float velocidad = 2f;

    public GameObject[] hearts;
    public int life;
    bool dead = false;
    void Update()
    {
        movimientoVertical();
        if (dead) Morir();
    }

    void movimientoVertical()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && position != 1)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velocidad), ForceMode2D.Impulse);
            position++;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && position != -1)
        {
            transform.Translate(Vector3.down * distancia);
            position--;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "objetoMadera")
        {
            TakeDamage(1);
        }
        else if(collision.gameObject.tag == "objetoHierro")
        {
            TakeDamage(2);
        }
    }
    void Morir()
    {
        Destroy(this.gameObject);
    }
    public void TakeDamage(int d)
    {
        if(d > 1)
        {
            for (int a = 0; a < d; a++) TakeDamage(1);
        }
        if(life > 0)
        {
            life -= d;
            Destroy(hearts[life].gameObject);
            if (life < 1) dead = true;
        }
        
    }

}

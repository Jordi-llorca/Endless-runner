using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    int position = 0;
    public float distancia = 3f;
    public float velocidad = 2f;

    void Start()
    {
        
    }

    
    void Update()
    {
        movimientoVertical();
    }

    void movimientoVertical()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //transform.Translate(Vector3.up * distancia * Time.deltaTime);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, velocidad), ForceMode2D.Impulse);
            position++;

        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.down * distancia);
            //GetComponent<Rigidbody2D>().AddForce(new Vector2(0, -velocidad/10), ForceMode2D.Impulse);
            position--;
        }
    }
    
}

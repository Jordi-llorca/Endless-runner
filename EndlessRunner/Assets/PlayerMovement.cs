using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int position = 0;
    public float distancia = 3f;
    public float velocidad = 2f;

    void Update()
    {
        movimientoVertical();
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
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoObstaculo : MonoBehaviour
{
    public float velocidad = 2f;
    void Update()
    {
        transform.Translate(Vector3.left * velocidad * Time.deltaTime);
    }
}

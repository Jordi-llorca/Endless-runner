using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    public float velocidad = 0.5f;
    void Update()
    {
        transform.Rotate(Vector3.forward * velocidad);
    }
}

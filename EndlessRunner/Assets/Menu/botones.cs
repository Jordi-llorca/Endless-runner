using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botones : MonoBehaviour
{
    public void EmpezarJuego()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitarJuego()
    {
        Application.Quit();
        Debug.Log("Salir");

    }

}

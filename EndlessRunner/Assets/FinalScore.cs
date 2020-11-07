using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScore : MonoBehaviour
{
    Text score;

    private void Start()
    {
        score = GetComponent<Text>();
    }
    void Update()
    {
        if (Score.scoreValue < 10)
            score.text = "0000" + Score.scoreValue;
        else if (Score.scoreValue < 100)
            score.text = "000" + Score.scoreValue;
        else if (Score.scoreValue < 1000)
            score.text = "00" + Score.scoreValue;
        else if (Score.scoreValue < 10000)
            score.text = "0" + Score.scoreValue;
        else if (Score.scoreValue < 10000)
            score.text = "" + Score.scoreValue;
        else
            score.text = "99999";
    }
}

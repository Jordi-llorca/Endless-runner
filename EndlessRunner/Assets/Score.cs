using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    public static int scoreValue = 0;
    float seg = 0;
    Text score;
    void Start()
    {
        scoreValue = 0;
        seg = 0;
        score = GetComponent<Text>();
    }

    void Update()
    {
       
        seg += Time.deltaTime;
        if (seg > 1) { scoreValue++; seg = 0; }
        if(scoreValue < 10)
            score.text = "0000" + scoreValue;
        else if(scoreValue < 100)
            score.text = "000" + scoreValue;
        else if (scoreValue < 1000)
            score.text = "00" + scoreValue;
        else if (scoreValue < 10000)
            score.text = "0" + scoreValue;
        else if (scoreValue < 10000)
            score.text = "" + scoreValue;
        else
            score.text = "99999";

    }
}

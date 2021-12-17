using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance; public int score { get; private set; }
    public TextMesh theText;


    public void Score()
    {
        score++;
        updateScore();
    }

    public void Begin()
    {
        score = 0;
        updateScore();
    }

    void updateScore()
    {
        string STRING = "";

        if(score < 100)
        {
            STRING += "0";
            if(score < 10)
            {
                STRING += "0";
            }
        }

        STRING += score.ToString();

        theText.text = STRING;
    }
}

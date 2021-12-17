using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCount : MonoBehaviour
{
    public static ScoreCount instance; public int score { get; private set; }
    public TextMesh theText; public TextMesh increase; bool increasing; int increaseAmount; float delay;

    void Awake()
    {
        instance = this;
        increasing = false;
        theText.text = "";
        increase.text = "";
    }

    public void Score()
    {
        increasing = true;
        delay = 0;
        score++;
        increaseAmount++;
        updateScore();
    }

    public void Update()
    {
        if(increasing)
        {
            delay+= Time.deltaTime;
            if(delay > 1.5f)
            {
                increasing = false;
                increaseAmount = 0;
                updateScore();
            }
        }
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

        if(increasing)
        {
            increase.text = "+" + increaseAmount.ToString();
        }
        else
        {
            increase.text = "";
        }
    }
}

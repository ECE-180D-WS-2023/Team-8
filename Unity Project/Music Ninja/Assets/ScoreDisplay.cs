using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ScoreDisplay : MonoBehaviour
{
    GameObject inputObject;
    getInput inputScript;
    int score;
    public Text scoreText;
    public int totalPossibleNotes;

    void Start()
    {
        inputObject = GameObject.Find("Hitbox Trigger Box");
        inputScript = inputObject.GetComponent<getInput>();
        score = inputScript.playerScore;
        Debug.Log("Score Display says score is: " + score);
    }

    void Update()
    {
        totalPossibleNotes = inputScript.possiblePoints / 4;
        score = inputScript.playerScore;
        //scoreText.text = score.ToString() + " / " + totalPossibleNotes;
        double percent = 0;
        if (totalPossibleNotes == 0)
        {
            percent = 0;
        } else
        {
            percent = Convert.ToDouble(score) / Convert.ToDouble(totalPossibleNotes);
        }
        percent = percent* 100;
        scoreText.text = score.ToString() + " / " + totalPossibleNotes + " = " + percent.ToString() + "% Accuracy";
    }

    void addScore()
    {
        score += 1;
    }

}

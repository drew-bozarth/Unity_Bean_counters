/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - Readouts.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Readouts : MonoBehaviour
{
    public Text Score;
    public Text GameResult;
    
    public void Reset()
    {
        ShowScore(0);
        HideGameResult();
    }
    
    public void ShowScore(int score)
    {
        if (score < 0)
            score = 0;
        Score.text = "Score: " + score;
    }
    
    public void ShowGameResult(int score, int objectTotal)
    {
        string grade = CalculateGrade(score, objectTotal);
        GameResult.text = "GAME OVER\nCollected " + 
                          score + "/" + objectTotal +
                          "\nGrade: " + grade;
    }

    public void HideGameResult()
    {
        GameResult.text = "";
    }

    private string CalculateGrade(int score, int total)
    {
        double numScore = (score * 100.0) / (total * 1.0);
        switch (numScore)
        {
            case > 93:
                return "A";
            case > 90:
                return "A-";
            case > 87:
                return "B+";
            case > 83:
                return "B";
            case > 80:
                return "B-";
            case > 77:
                return "C+";
            case > 73:
                return "C";
            case > 70:
                return "C-";
            case > 67:
                return "D+";
            case > 63:
                return "D";
            case > 60:
                return "D-";
            default:
                return "F";
        }
    }
}

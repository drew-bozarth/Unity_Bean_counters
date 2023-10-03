/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - Timer.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    private bool TimerOn = false;

    public Text TimerTxt;
    public Game Game;

    public void StartTimer()
    {
        TimerOn = true;
    }
    
    // use a couroutine to start the timer after 3 seconds, so as to allow time for the '3..2..1..Go!' countdown to finish

    private IEnumerator waitThreeSeconds()
    {
        yield return new WaitForSeconds(3);
        TimerOn = true;
    }
    private void Update()
    {
        if (TimerOn)
        {
            if (TimeLeft > 0)
            {
                TimeLeft -= Time.deltaTime;
                updateTimer(TimeLeft);
            }
            else
            {
                Debug.Log("Time is UP!");
                TimeLeft = 0;
                TimerOn = false;
                Game.TimeIsUp();
            }
        }
    }

    private void updateTimer(float currentTime)
    {
        currentTime += 1;

        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("Time: " + "{0:00}:{1:00}", minutes, seconds);
    }
}

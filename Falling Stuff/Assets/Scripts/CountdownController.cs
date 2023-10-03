/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - CountdownController.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public Text countdownTextField;
    public Game game;

    public void StartCountdown()
    {
        StartCoroutine(CountdownCoroutine());
    }

    private IEnumerator CountdownCoroutine()
    {
        countdownTextField.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "Go!";
        // start the game here
        yield return new WaitForSeconds(1.0f);
        countdownTextField.text = "";
        yield return null;
        game.StartGame();
    }
}

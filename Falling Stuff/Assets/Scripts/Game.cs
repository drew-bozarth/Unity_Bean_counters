/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - Game.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public static Game Instance;
    public Readouts Readouts;
    public Player Player;
    public CountdownController CountdownController;
    public Timer Timer;
    public CoffeePlacer CoffeePlacer;
    public FishPlacer FishPlacer;
    private int score;
    private bool timerUp = false;
    private int objectsSpawned;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this.gameObject);
        else
            Instance = this;
    }
    
    public void Start()
    {
        Reset();
        Player.Disable();
        CountdownController.StartCountdown();
    }

    public void StartGame()
    {
        Player.Enable();
        CoffeePlacer.StartPlacing();
        FishPlacer.StartPlacing();
        Timer.StartTimer();
    }
    
    private void FixedUpdate()
    {
        CheckIfGameOver();
    }
    
    public void DisableGamePlay()
    {
        Player.Disable();
    }

    public void DisableSpawning()
    {
        CoffeePlacer.StopPlacing();
        FishPlacer.StopPlacing();
    }
    
    public void CoffeeGrabbed()
    {
        UpdateScore(score + 1);
        CheckIfGameOver();
    }
    
    public void CoffeeBreak()
    {
        CheckIfGameOver();
    }
    
    public void FishHitPlayer()
    {
        UpdateScore(score - 1);
        CheckIfGameOver();
    }
    
    public void FishBreak()
    {
        CheckIfGameOver();
    }

    public void TimeIsUp()
    {
        timerUp = true;
    }
    
    private void CheckIfGameOver()
    {
        if (timerUp)
        {
            DisableSpawning();
            if (CountObjects() == 0)
            {
                DisableGamePlay();
                WinGame();
            }
        }
    }
    
    private void WinGame()
    {
        objectsSpawned = CoffeePlacer.GetCoffeeCount();
        Readouts.ShowGameResult(score, objectsSpawned);
        StartCoroutine(WaitToRestart());
    }

    IEnumerator WaitToRestart()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(0);
    }
    
    private void Reset()
    {
        score = 0;
        objectsSpawned = 0;
        Readouts.Reset();
    }
    
    private void UpdateScore(int newScore)
    {
        score = newScore;
        Readouts.ShowScore(score);
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private int CountObjects()
    {
        int coffee = GameObject.FindGameObjectsWithTag("Coffee").Length;
        int fish = GameObject.FindGameObjectsWithTag("Fish").Length;
        return coffee + fish;
    }
}

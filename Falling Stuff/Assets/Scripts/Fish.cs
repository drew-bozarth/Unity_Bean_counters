/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - Fish.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : DeathEffectObject
{
    public GameObject FloatingScorePrefab;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Instantiate(FloatingScorePrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Game.Instance.FishHitPlayer();
        }
        if (collision.gameObject.CompareTag("BottomWall"))
        {
            CreateDeathEffect();
            Destroy(gameObject);
            Game.Instance.FishBreak();
        }
    }
}

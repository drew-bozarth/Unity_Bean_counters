/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - DelayedSelfDestruction.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSelfDestruction : MonoBehaviour
{
    public float DelayInSeconds = 1f;
    void Start()
    {
        Destroy(gameObject, DelayInSeconds);
    }
}


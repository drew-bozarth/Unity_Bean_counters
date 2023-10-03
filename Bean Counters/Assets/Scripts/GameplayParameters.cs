/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - GameplayParameters.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayParameters : MonoBehaviour
{
    public static float PlayerMoveAmount = 0.025f;
    public static float SecondsUnderFish = 2.5f;

    public static int CoffeeMinimumTimeToNextCreation = 1;
    public static int CoffeeMaximumTimeToNextCreation = 1;
    //public static int BoneSecondsOnScreen = 20;
    
    public static int FishMinimumTimeToNextCreation = 3;
    public static int FishMaximumTimeToNextCreation = 7;
    //public static int FishSecondsOnScreen = 20;
}

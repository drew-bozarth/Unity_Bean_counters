/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - FishPlacer.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishPlacer : ObjectPlacer
{
    public override void StartPlacing()
    {
        base.StartPlacing();
        minimumTimeToNextCreation = GameplayParameters.FishMinimumTimeToNextCreation;
        maximumTimeToNextCreation = GameplayParameters.FishMaximumTimeToNextCreation;
    }

    protected override void Create()
    {
        base.Create();
        Instantiate(Prefab, ScreenPositionTools.RandomTopOfScreenLocation(), Quaternion.identity);
    }
}

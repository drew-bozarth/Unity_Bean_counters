/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - CoffeePlacer.cs
*/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeePlacer : ObjectPlacer
{
    private int coffeeCount;

    private void Reset()
    {
        coffeeCount = 0;
    }

    public override void StartPlacing()
    {
        base.StartPlacing();
        minimumTimeToNextCreation = GameplayParameters.CoffeeMinimumTimeToNextCreation;
        maximumTimeToNextCreation = GameplayParameters.CoffeeMaximumTimeToNextCreation;
    }

    protected override void Create()
    {
        base.Create();
        Instantiate(Prefab, ScreenPositionTools.RandomTopOfScreenLocation(), Quaternion.identity);
        coffeeCount += 1;
    }

    public int GetCoffeeCount()
    {
        return coffeeCount;
    }
}

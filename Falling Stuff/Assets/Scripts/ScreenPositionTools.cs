/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - ScreenPositionTools.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenPositionTools
{
    public static Vector3 RandomScreenLocation()
    {
        float randomX = Random.Range(0, Screen.width);
        float randomY = Random.Range(0, Screen.height);

        return new Vector3(randomX, randomY, 10);
    }

    public static Vector3 RandomWorldLocation(Camera camera)
    {
        Vector3 randomScreenLocation = RandomScreenLocation();
        return camera.ScreenToWorldPoint(randomScreenLocation);
    }

    public static Vector3 RandomTopOfScreenLocation()
    {
        float randomX = Random.Range(-6, 6);
        return new Vector3(randomX, 6, -5);
    }

    public static Vector3 RandomTopOfScreenWorldLocation(Camera camera)
    {
        Vector3 randomTopOfScreenLocation = RandomTopOfScreenLocation();
        return camera.ScreenToWorldPoint(randomTopOfScreenLocation);
    }
}

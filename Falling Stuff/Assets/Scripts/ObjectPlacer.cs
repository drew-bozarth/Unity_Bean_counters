/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - ObjectPlacer.cs
*/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPlacer : MonoBehaviour
{
    public Camera Camera;
    public GameObject Prefab;

    protected bool isWaitingToCreate = false;
    protected bool isPlacing = false;
    protected int minimumTimeToNextCreation = 1;
    protected int maximumTimeToNextCreation = 3;
    protected int secondsUntilNextCreation;

    public virtual void Start()
    {
        isPlacing = false;
    }
    
    public virtual void StartPlacing()
    {
        isPlacing = true;
        isWaitingToCreate = false;
    }

    public virtual void StopPlacing()
    {
        isPlacing = false;
    }

    public void FixedUpdate()
    {
        if (isPlacing)
        {
            if (!isWaitingToCreate)
            {
                isWaitingToCreate = true;
                secondsUntilNextCreation = Random.Range(minimumTimeToNextCreation, maximumTimeToNextCreation + 1);
                StartCoroutine(CountdownUntilCreation());
            }
        }
        else
        {
            isWaitingToCreate = true;
        }
        
    }

    IEnumerator CountdownUntilCreation()
    {
        yield return new WaitForSeconds(secondsUntilNextCreation);

        if (isPlacing)
        {
            Create();
        }
    }

    protected virtual void Create()
    {
        isWaitingToCreate = false;
    }
}

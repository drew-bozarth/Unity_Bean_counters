/*
CPSC245_Project1_BOZARTH_CLEMENTS
Drew Bozarth | Ryan Clements
2373658 | 2374337
dbozarth@chapman.edu | rclements@chapman.edu
CPSC 245-01
Exam 1 - Falling Stuff - InputController.cs
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InputController : MonoBehaviour
{
    public Player player;
    public UnityEvent onInputLeft;
    public UnityEvent onInputRight;

    private void Update()
    {
        GetInput();
    }
    private void GetInput()
    {
        // normal input for up and down, NOT USED HERE
        /*
        if (Input.GetKey(KeyCode.W))
        {
            player.TryToMove(new Vector2(0, 1));
        }
        */
        /*
        if (Input.GetKey(KeyCode.S))
        {
            player.TryToMove(new Vector2(0, -1));
        }
        */
        // normal input
        /*
        if (Input.GetKey(KeyCode.A))
        {
            player.TryToMove(new Vector2(-1, 0));
        }
        if (Input.GetKey(KeyCode.D))
        {
            player.TryToMove(new Vector2(1, 0));
        }
        */
        // Input using Unity events
        if (Input.GetKey(KeyCode.A))
        {
            SendMoveEvent(KeyCode.A);
        }
        if (Input.GetKey(KeyCode.D))
        {
            SendMoveEvent(KeyCode.D);
        }
    }
    private void SendMoveEvent(KeyCode keyCode)
    {
        switch (keyCode)
        {
            case KeyCode.W:
                // not used
                break;
            case KeyCode.A:
                onInputLeft.Invoke();
                break;
            case KeyCode.S:
                // not used
                break;
            case KeyCode.D:
                onInputRight.Invoke();
                break;
        }
    }
    public void ToggleInput(bool isOn)
    {
        gameObject.SetActive(isOn);
    }
}

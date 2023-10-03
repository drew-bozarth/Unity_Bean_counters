using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatePlaying : PlayerStates
{
    public PlayerStatePlaying(Player manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "<state: resume>";
        Debug.Log(stateEnteredMessage);
        
        //playerManger.EnterStatePlaying();
    }
    public override void OnMyStateExit()
    {
        string stateEnteredMessage = "<state: >";
        Debug.Log(stateEnteredMessage);
        
        //playerManger.ExitStatePlaying();
    }
}

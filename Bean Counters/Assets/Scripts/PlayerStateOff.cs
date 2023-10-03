using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateOff : PlayerStates
{
    public PlayerStateOff(Player manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "<state: resume>";
        Debug.Log(stateEnteredMessage);

        //.EnterStateOff();
    }
    public override void OnMyStateExit()
    {
        string stateEnteredMessage = "<state: >";
        Debug.Log(stateEnteredMessage);
        
        //playerManger.ExitStateOff();
    }
}

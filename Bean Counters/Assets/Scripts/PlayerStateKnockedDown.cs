using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateKnockedDown : PlayerStates
{
    public PlayerStateKnockedDown(Player manager) : base(manager) { }

    public override void OnMyStateEntered()
    {
        string stateEnteredMessage = "<state: resume>";
        Debug.Log(stateEnteredMessage);
        
        //playerManger.EnterStateKnockedDown();
    }
    public override void OnMyStateExit()
    {
        string stateEnteredMessage = "<state: >";
        Debug.Log(stateEnteredMessage);
        
        //playerManger.ExitStateKnockedDown();
    }
}

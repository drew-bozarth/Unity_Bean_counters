using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStates
{
    public enum stopWatchStates
    {
        off,
        playing,
        knockedDown
    }
    
    protected Player playerManager;
    public PlayerStates(Player player)
    {
        playerManager = player;
    }
    
    public virtual void OnMyStateEntered(){}
    public virtual void OnMyStateExit(){}
    public virtual void StateUpdate(){}
    // unused
    public virtual void OnStateReceived(PlayerStates playerState){}
}

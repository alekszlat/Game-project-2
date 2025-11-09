using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovingState : GroundedState
{
    private TimerUtil playerMovingStateTimer = new TimerUtil(0.1f, true);
    public override void Enter(Player stateController)
    {
      
        base.Enter(stateController);
        Debug.Log("MOVING state");
    }

    public override void Exit(Player stateController)
    {
         base.Exit(stateController);
       
    }

    public override void FixedUpdate(Player stateController)
    {
        base.FixedUpdate(stateController);

    }

    //TODO add a timer to cooldown for switching classes

    public override void Update(Player stateController)
    {
  
        base.Update(stateController);
        //Switching player movement Animations


        //If player has stopped moving and a small period has passed he goes into idle

        bool hasStopped = stateController.GetMoveDir() == Vector2.zero;
        if (hasStopped && playerMovingStateTimer.UpdateTimer(Time.deltaTime))
        {
            stateController.SwitchState(stateController.playerIdleState, stateController);
        }
    }
}

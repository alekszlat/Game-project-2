using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : GroundedState
{
    private TimerUtil playerIdleStateTimer = new TimerUtil(0.1f, true);
    public override void Enter(Player stateController)
    {
        //base.Enter(stateController);
        Debug.Log("idleState");
    }

    public override void Exit(Player stateController)
    {
        base.Exit(stateController);
       
    }

    public override void FixedUpdate(Player stateController)
    {
        base.FixedUpdate(stateController);
      
    }
    
    public override void Update(Player stateController)
    {
        
       
        base.Update(stateController);


        //Switching Sprite Sheet based on the direction
        bool hasStartedMoving = stateController.GetMoveDir() != Vector2.zero;
        if (hasStartedMoving && playerIdleStateTimer.UpdateTimer(Time.deltaTime))
        {
            stateController.SwitchState(stateController.playerMovingState,stateController);
        }
    }

}

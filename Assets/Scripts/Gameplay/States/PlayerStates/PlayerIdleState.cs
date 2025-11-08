using UnityEngine;

public class PlayerIdleState : GroundedState
{
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
    //TODO add a timer to cooldown for switching classes
    public override void Update(Player stateController)
    {
        base.Update(stateController);
        if (stateController.playerInputHandler.GetDirection() != Vector2.zero)
        {
            stateController.SwitchState(stateController.playerMovingState,stateController);
        }
    }

}

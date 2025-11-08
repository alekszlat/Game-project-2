using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovingState : GroundedState
{
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

    public override void Update(Player stateController)
    {
       // base.Update(stateController);
        
        if (stateController.GetMoveDir() == Vector2.zero)
        {
            stateController.SwitchState(stateController.playerIdleState,stateController);
        }
    }
}

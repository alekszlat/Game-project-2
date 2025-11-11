using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : GroundedState
{
    TimerUtil idleStateTimer = new TimerUtil(0.01f, true);
    private int oldAnimation=-1;
    public override void Enter(Player stateController)
    {
        //base.Enter(stateController);
        Debug.Log("idleState");
        oldAnimation = -1;
    }

    public override void Exit(Player stateController)
    {
        base.Exit(stateController);
       
    }

    public override void FixedUpdate(Player stateController)
    {
       base.FixedUpdate(stateController);
       Rigidbody2D rb= stateController.GetComponent<Rigidbody2D>();
       rb.linearVelocity = Vector2.zero;
    }
    
    public override void Update(Player stateController)
    {
        Vector2 lookDir = stateController.GetLookDir();//Direction the player is looking at
       
        base.Update(stateController);
        Animator animator = stateController.GetAnimator();
        int currentAnimation = -1;
                              
        if (lookDir.x > 0.01f)
        {
            currentAnimation = stateController.horizontalIdle;
        }
        else if (lookDir.x < -0.01f)
        {
            currentAnimation = stateController.horizontalIdle;
        }
        else if (lookDir.y > 0.01f)
        {
            currentAnimation = stateController.UpIdle;
        }
        else if (lookDir.y < -0.01f)
        {
            currentAnimation = stateController.DownIdle;
        }
        else
        {
            currentAnimation = stateController.horizontalIdle;
        }

        //if the animation is diffrent from the last one we switch and save the new one as old animation
        if (currentAnimation != oldAnimation)
        {
            oldAnimation = currentAnimation;
            animator.CrossFade(currentAnimation, 0.1f);
        }
    

        bool hasStartedMoving = stateController.GetInputMoveDir() != Vector2.zero;
        if (hasStartedMoving && idleStateTimer.UpdateTimer(Time.deltaTime))
        {
            stateController.SwitchState(stateController.playerMovingState,stateController);
        }
    }

}

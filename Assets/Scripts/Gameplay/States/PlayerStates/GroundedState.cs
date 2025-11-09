using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class GroundedState : PlayerState
{
    public override void Enter(Player stateController)
    {
       
    }

    public override void Exit(Player stateController)
    {
       
    }

    public override void FixedUpdate(Player stateController)
    {
        stateController.Movement();
    }

    public override void Update(Player stateController)
    {
       
    }

 
}

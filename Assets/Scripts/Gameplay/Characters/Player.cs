using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : Character<Player>
{
    //Monobehavior class that keeps track of the player input
    public PlayerInputServece playerInputHandler;
  

    //Diffrent player states
    public PlayerIdleState playerIdleState;
    public PlayerMovingState playerMovingState;
    public PlayerDialogueState playerDialogueState;
   
  

    public override void Start()
    {
        base.Start();
       
   
        playerIdleState = new PlayerIdleState();
        playerMovingState = new PlayerMovingState();
        playerDialogueState = new PlayerDialogueState();

        SetSpeed(6);

        playerInputHandler = GetComponent<PlayerInputServece>();

        SetState(playerIdleState);

       
     

    }
    private void FixedUpdate()
    {
        FixedUpdateCurrentState(this);
    }
    public override void Update()
    {
        base.Update();

        SetMoveDir(playerInputHandler.GetDirection());

        UpdateCurrentState(this);

     

       
    }
 
}

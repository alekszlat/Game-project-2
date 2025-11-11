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

    //Animation
    public readonly int horizontalMovement = Animator.StringToHash("MoveHorizontal");
    public readonly int UpMovement = Animator.StringToHash("MoveUp");
    public readonly int DownMovement = Animator.StringToHash("MoveDown");
    public readonly int horizontalIdle = Animator.StringToHash("IdleHorizontal");
    public readonly int UpIdle = Animator.StringToHash("IdleUp");
    public readonly int DownIdle = Animator.StringToHash("IdleDown");
  
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

        SetInputMoveDir(playerInputHandler.GetDirection());

        UpdateCurrentState(this);
  
    }
  
}

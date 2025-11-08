using UnityEngine;

public class Player : Character<Player>
{
    //Monobehavior class that keeps track of the player input
    public PlayerInputServece playerInputHandler;
    
    //Diffrent player states
    public PlayerIdleState playerIdleState = new PlayerIdleState();
    public PlayerMovingState playerMovingState = new PlayerMovingState();
    public PlayerDialogueState playerDialogueState = new PlayerDialogueState();

    public override void Start()
    {
        base.Start();
        SetSpeed(6);
        playerInputHandler = GetComponent<PlayerInputServece>();
        SetState(playerIdleState);

    }
    private void FixedUpdate()
    {
        FixedUpdateCurrentState(this);
    }
    void Update()
    {
        UpdateCurrentState(this);
        SetMoveDir(playerInputHandler.GetDirection());
        Debug.Log(GetMoveDir());
    }
  
}

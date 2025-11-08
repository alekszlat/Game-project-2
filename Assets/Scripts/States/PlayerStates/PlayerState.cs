using UnityEngine;

public abstract class PlayerState : State<Player>
{

    public abstract void Enter(Player stateController);

    public abstract void Exit(Player stateController);
 
    public abstract void FixedUpdate(Player stateController);
   
    public abstract void Update(Player stateController);
   
}

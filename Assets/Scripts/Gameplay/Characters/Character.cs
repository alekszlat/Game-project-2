using UnityEngine;


public abstract class Character<T> : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir;
    private float speed;
    private State<T> currentState;//needs a template for each class that extends character: state for Player,for passiveNPC,for agressiveNpc

    //is virtual so we can intialize rb
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //switches between states, it needs a new state,state needs its controller as a paramater so it can acess it, and we need the controller
    //when we switch states, we do the Exit function on the current one, switcht o the new one and start the Enter function.
    public void SwitchState(State<T> state, T stateController)
    {
        state.Exit(stateController);
        currentState = state;
        state.Enter(stateController);
    }
    public void SetState(State<T> state)
    {
        currentState = state;
    }
    //These areused to Switch the current state witouth breaking capsulation
    public void UpdateCurrentState(T stateController)
    {
        currentState.Update(stateController);
    }
    public void EnterCurrentState(T stateController)
    {
        currentState.Enter(stateController);
    }
    public void FixedUpdateCurrentState(T stateController)
    {
        currentState.FixedUpdate(stateController);
    }
    public void ExitUpdateCurrentState(T stateController)
    {
        currentState.FixedUpdate(stateController);
    }

    //Helper functions
    public void Movement()
    {
        rb.linearVelocity = moveDir * speed;
    }

    //Geters and Setters
    public State<T> getCurrentState()
    {
        return currentState;
    }
    public Vector2 GetMoveDir()
    {
        return moveDir;
    }
    public void SetMoveDir(Vector2 moveDir)
    {
        this.moveDir = moveDir;
    }
    public void SetSpeed(float speed)
    {
        this.speed=speed;
    }
}

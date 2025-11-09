using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;


public abstract class Character<T> : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 moveDir;//direction currently moving towords
    private Vector2 lastMoveDir;//last direction we were moving in
    private float speed;
    private State<T> currentState;//needs a template for each class that extends character: state for Player,for passiveNPC,for agressiveNpc


    private AnimationControllerUtil animationController = new AnimationControllerUtil();//class that handles animation,needs lists with sprites

    private SpriteRenderer spriteRenderer;
    //is virtual so we can intialize rb
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        lastMoveDir = Vector2.down;
     
      
    }
    //Updates animation controller in every state
    public virtual void Update()
    {
        animationController.UpdateAnimationController(Time.deltaTime);

        //Initialized Sprite renderer and changes current sprite
        if (animationController.HasSprites())
        {
            spriteRenderer.sprite = animationController.GetSprite();
        }
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
        if (moveDir != Vector2.zero)
        {
            lastMoveDir = moveDir;
        }
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
    public void setSprite(Sprite currentSprite)
    {
        spriteRenderer.sprite = currentSprite;
    }
    public AnimationControllerUtil GetAnimationController()
    {
        return animationController;
    }
 
    public Vector2 GetLastMoveDir()
    {
        return lastMoveDir;
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    protected float currentSpeed;

    protected Animator animator;
    protected PlayerController player;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;

    public void Initialize(Animator animator,PlayerController playerController,PlayerInput playerInput, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.player = playerController;
        this.input = playerInput;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void LogicUpdate()
    {

    }

    public virtual void PhysicUpdate()
    {

    }

   
}

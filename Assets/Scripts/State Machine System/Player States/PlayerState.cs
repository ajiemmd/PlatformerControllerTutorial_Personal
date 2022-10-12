using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : ScriptableObject,IState
{
    [SerializeField] string stateName;
    [SerializeField, Range(0,1f)] float transitionDuration = 0.1f;//动画交叉淡化的时间(动画时长百分比)

    float stateStartTime;

    int stateHash;

    protected float currentSpeed;

    protected Animator animator;
    protected PlayerController player;
    protected PlayerInput input;
    protected PlayerStateMachine stateMachine;

    protected bool IsAnimationFinished => StateDuration >= animator.GetCurrentAnimatorStateInfo(0).length;

    protected float StateDuration => Time.time - stateStartTime;

    void OnEnable()
    {
        stateHash = Animator.StringToHash(stateName);

    }

    public void Initialize(Animator animator,PlayerController playerController,PlayerInput playerInput, PlayerStateMachine stateMachine)
    {
        this.animator = animator;
        this.player = playerController;
        this.input = playerInput;
        this.stateMachine = stateMachine;
    }


    public virtual void Enter()
    {
        animator.CrossFade(stateHash, transitionDuration);
        stateStartTime = Time.time;
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

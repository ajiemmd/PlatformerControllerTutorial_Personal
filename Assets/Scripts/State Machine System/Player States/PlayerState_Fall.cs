using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Fall", fileName = "PlayerState_Fall")]

public class PlayerState_Fall : PlayerState
{
    [SerializeField] AnimationCurve speedCurve;

    [SerializeField] float moveSpeed = 5f;

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        if (player.IsGrounded)
        {
            stateMachine.SwitchState(typeof(PlayerState_Land));
        }

        if (input.Jump)
        {
            //Switch to Air Jump State
        }
    }

    public override void PhysicUpdate()
    {
        player.Move(moveSpeed);
        player.SetVelocityY(speedCurve.Evaluate(StateDuration));
    }

}

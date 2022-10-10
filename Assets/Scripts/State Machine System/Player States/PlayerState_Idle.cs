using UnityEngine;

[CreateAssetMenu(menuName = "Data/StateMachine/PlayerState/Idle", fileName = "PlayerState_Idle")]
public class PlayerState_Idle : PlayerState
{
    public override void Enter()
    {
        animator.Play("Idle");

        player.SetVelocityX(0f);
    }

    public override void LogicUpdate()
    {
        //if (Keyboard.current.aKey.isPressed || Keyboard.current.dKey.isPressed)
        if (input.Move)
        {
            stateMachine.SwitchState(typeof(PlayerState_Run));
        }

    }
}

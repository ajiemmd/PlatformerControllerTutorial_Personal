using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [SerializeField] PlayerState[] states;

    Animator animator;

    PlayerController player;

    PlayerInput input;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        input = GetComponent<PlayerInput>();

        player = GetComponent<PlayerController>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator, player, input, this);
            stateTable.Add(state.GetType(), state);
        }


    }

    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);

        MethodInfo info = this.GetType().GetMethod("Update");
    }

}

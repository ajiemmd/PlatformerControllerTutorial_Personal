using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerStateMachine : StateMachine
{

    [SerializeField] PlayerState[] states;

    Animator animator;


    private void Awake()
    {   
        animator = GetComponentInChildren<Animator>();

        stateTable = new Dictionary<System.Type, IState>(states.Length);

        foreach (PlayerState state in states)
        {
            state.Initialize(animator, this);
            stateTable.Add(state.GetType(), state);
        }

   
    }

    private void Start()
    {
        SwitchOn(stateTable[typeof(PlayerState_Idle)]);

        MethodInfo info = this.GetType().GetMethod("Update");
    }

}

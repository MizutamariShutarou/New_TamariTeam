using System;
using UnityEngine;

public class SantaState00Base : IState
{
    [AnimationParameter, SerializeField]
    protected string _enterAnimParameterName = default;
    public string AnimParameterName => _enterAnimParameterName;
    [NonSerialized]
    protected SantaStateMachine _stateMachine = null;

    public virtual void Init(SantaStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }
}

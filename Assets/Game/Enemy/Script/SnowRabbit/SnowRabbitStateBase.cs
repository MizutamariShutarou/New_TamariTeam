using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowRabbitStateBase : IState
{
    [System.NonSerialized]
    protected SnowRabbitStateMachine _snowRabbitStateMachine;

    public virtual void Init(SnowRabbitStateMachine snowRabbitStateMachine)
    {
        _snowRabbitStateMachine = snowRabbitStateMachine;
    }
    public virtual void Enter()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Exit()
    {
        throw new System.NotImplementedException();
    }

    public virtual void Update()
    {
        throw new System.NotImplementedException();
    }
}

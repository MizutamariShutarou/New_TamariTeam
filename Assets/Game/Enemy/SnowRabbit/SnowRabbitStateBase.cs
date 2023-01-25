using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SnowRabbitStateBase : IState
{
    [System.NonSerialized]
    protected SnowRabbitStateMachine _snowRabbitStateMachine;

    public virtual void Init(SnowRabbitStateMachine snowRabbitStateMachine)
    {
        _snowRabbitStateMachine = snowRabbitStateMachine;
    }
    public void Enter()
    {
        throw new System.NotImplementedException();
    }

    public void Exit()
    {
        throw new System.NotImplementedException();
    }

    public void Update()
    {
        throw new System.NotImplementedException();
    }
}

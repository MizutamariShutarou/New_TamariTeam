using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowmanStateBase : IState
{
    [System.NonSerialized]
    protected SnowmanStateMachine _snowmanStateMachine;

    public void Init(SnowmanStateMachine snowmanStateMachine)
    {
        _snowmanStateMachine = snowmanStateMachine;
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

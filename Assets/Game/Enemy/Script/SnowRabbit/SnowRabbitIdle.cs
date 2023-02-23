using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ƒvƒŒƒCƒ„[‚ª‹ß‚Ã‚¢‚½‚çŒü‚©‚Á‚Ä‚­‚éŒn‚Ì“G‚É‚Â‚©‚¤‚©‚à
/// </summary>

[System.Serializable]
public class SnowRabbitIdle : SnowRabbitStateBase
{
    public override void Enter()
    {
        Debug.Log("EnterIdle");
    }
    public override void Update()
    {
        if(_snowRabbitStateMachine.Controller.InCamera())
        {
            _snowRabbitStateMachine.TransitionTo(_snowRabbitStateMachine.snowRabbitMove);
            return;
        }
    }
    public override void Exit()
    {
        Debug.Log("ExitIdle");
    }
}

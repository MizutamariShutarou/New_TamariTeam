using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowRabbitMove : SnowRabbitStateBase
{
    public override void Enter()
    {
        Debug.Log("EnterMove");
        _snowRabbitStateMachine.Controller.CanMove = true;
    }
    public override void Exit()
    {
        Debug.Log("ExitMove");
        _snowRabbitStateMachine.Controller.CanMove = false;
    }
    public override void Update()
    {
        if(!_snowRabbitStateMachine.Controller.InCamera())
        {
            _snowRabbitStateMachine.TransitionTo(_snowRabbitStateMachine.snowRabbitIdle);
            return;
        }
        //if(_snowRabbitStateMachine.Controller.Status.Hp <= 0)
        //{
        //    _snowRabbitStateMachine.TransitionTo(_snowRabbitStateMachine.snowRabbitDeath);
        //    return;
        //}
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �v���C���[���߂Â�����������Ă���n�̓G�ɂ�������
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

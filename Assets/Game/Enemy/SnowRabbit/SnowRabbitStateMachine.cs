using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowRabbitStateMachine : StateMachineBase
{
    [SerializeField]
    private SnowRabbitIdle _snowRabbitIdle;

    [SerializeField]
    private SnowRabbitMove _snowRabbitMove;

    [SerializeField]
    private SnowRabbitDeath _snowRabbitDeath;

    public SnowRabbitIdle snowRabbitIdle => _snowRabbitIdle;

    public SnowRabbitMove snowRabbitMove => _snowRabbitMove;

    public SnowRabbitDeath snowRabbitDeath => _snowRabbitDeath; 

    private SnowRabbitController _snowRabbitController;
    public void Init(SnowRabbitController snowRabbitController)
    {
        _snowRabbitController = snowRabbitController;
        Initialize(_snowRabbitIdle);
    }

    protected override void StateInit()
    {
        _snowRabbitIdle.Init(this);
        _snowRabbitMove.Init(this);
        _snowRabbitDeath.Init(this);
    }
}

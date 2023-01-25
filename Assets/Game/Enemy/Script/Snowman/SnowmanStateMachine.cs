using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowmanStateMachine : StateMachineBase
{
    [SerializeField]
    private SnowmanIdle _snowmanIdle;

    [SerializeField]
    private SnowmanMove _snowmanMove;

    [SerializeField]
    private SnowmanAttack _snowmanAttack;

    [SerializeField]
    private SnowmanDeath _snowmanDeath;

    public SnowmanIdle SnowmanIdle => _snowmanIdle;
    public SnowmanMove SnowmanMove => _snowmanMove;
    public SnowmanAttack SnowmanAttack => _snowmanAttack;
    public SnowmanDeath SnowmanDeath => _snowmanDeath;

    private SnowmanController _snowmanController;

    public void Init(SnowmanController snowmanController)
    {
        _snowmanController = snowmanController;
        Initialize(_snowmanIdle);
    }

    protected override void StateInit()
    {
        _snowmanIdle.Init(this);
        _snowmanMove.Init(this);
        _snowmanAttack.Init(this);
        _snowmanDeath.Init(this);
    }
}
    


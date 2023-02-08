using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SnowRabbitMove : SnowRabbitStateBase
{
    [SerializeField]
    private float _speed = default;

    public override void Update()
    {
        //if(ƒ†ƒjƒIƒ“‚É“¥‚Ü‚ê‚½‚ç)
        {
            _snowRabbitStateMachine.TransitionTo(_snowRabbitStateMachine.snowRabbitDeath);
        }
    }
}

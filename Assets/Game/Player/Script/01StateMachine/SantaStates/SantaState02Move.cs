// 日本語対応
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SantaState02Move : SantaState00Base
{
    public override void Update()
    {
        // 移動入力が消失したときにIdleStateに遷移する
        // if(省略)
        {
            _stateMachine.TransitionTo(_stateMachine.Idle);
            return;
        }
        // 接地していて,かつ,ジャンプ入力が発生したときにJumpStateに遷移する
        // if(省略)
        {
            _stateMachine.TransitionTo(_stateMachine.Jump);
            return;
        }
    }
}

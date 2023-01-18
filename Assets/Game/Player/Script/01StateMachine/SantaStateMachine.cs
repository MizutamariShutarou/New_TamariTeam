using System;
using UnityEngine;

[System.Serializable]
public class SantaStateMachine : StateMachineBase
{
    [SerializeField]
    private SantaState01Idle _idle = default;
    [SerializeField]
    private SantaState02Move _move = default;
    [SerializeField]
    private SantaState03Jump _jump = default;

    public SantaState01Idle Idle => _idle;
    public SantaState02Move Move => _move;
    public SantaState03Jump Jump => _jump;

    private SantaController _santaController = null;
    public void Init(SantaController santaController)
    {
        _santaController = santaController;
        Initialize(_idle);

        // アニメーションの変更処理
        // 実装可能段階になったらコメントインする。
        //OnStateChanged += (previousState, nextState) =>
        //{
        //    // 前のステート独自のアニメーションパラメータ名をfalseにし、
        //    // 次のステート独自のアニメーションパラメータ名をtrueにする。
        //    if (previousState is SantaState00Base)
        //    {
        //        _santaController.Animator?.SetBool(
        //            (previousState as SantaState00Base).AnimParameterName, false);
        //    }
        //    if (nextState is SantaState00Base)
        //    {
        //        _santaController.Animator?.SetBool(
        //            (nextState as SantaState00Base).AnimParameterName, true);
        //    }
        //};
    }
    protected override void StateInit()
    {
        _idle.Init(this);
        _move.Init(this);
        _jump.Init(this);
    }
}

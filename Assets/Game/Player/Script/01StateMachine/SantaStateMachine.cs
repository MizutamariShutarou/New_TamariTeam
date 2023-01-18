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

        // �A�j���[�V�����̕ύX����
        // �����\�i�K�ɂȂ�����R�����g�C������B
        //OnStateChanged += (previousState, nextState) =>
        //{
        //    // �O�̃X�e�[�g�Ǝ��̃A�j���[�V�����p�����[�^����false�ɂ��A
        //    // ���̃X�e�[�g�Ǝ��̃A�j���[�V�����p�����[�^����true�ɂ���B
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

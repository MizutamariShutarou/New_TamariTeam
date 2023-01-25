using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// ���[�U�[����̓��͂𐧌䂷��N���X
    /// </summary>
    public class Input
    {
        private GameController _inputActions = null;
        public GameController InputActions => _inputActions;
        private Dictionary<InputType, InputAction> _inputs = new Dictionary<InputType, InputAction>();

        /// <summary> ���̃N���X�̏��������� </summary>
        public void Init()
        {
            // InputSystem���擾��,�N������B
            _inputActions = new GameController();
            _inputActions.Enable();
            InputActionInit();
        }

        /// <summary>
        /// ���͂������������Ɏ��s���鏈����o�^����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started += inputAction;
        }
        /// <summary>
        /// ���͂��������Ă���ԁA���s���鏈����o�^����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed += inputAction;
        }
        /// <summary>
        /// ���͂��Ȃ��Ȃ������Ɏ��s���鏈����o�^����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled += inputAction;
        }

        /// <summary>
        /// ���͂������������Ɏ��s���鏈������������
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started -= inputAction;
        }
        /// <summary>
        /// ���͂��������Ă���ԁA���s���鏈������������
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed -= inputAction;
        }
        /// <summary>
        /// ���͂��Ȃ��Ȃ������Ɏ��s���鏈������������
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled -= inputAction;
        }
        /// <summary>
        /// Dictionary����������
        /// </summary>
        private void InputActionInit()
        {
            _inputs.Add(InputType.Move, _inputActions.Player.Move);
            _inputs.Add(InputType.Fire1, _inputActions.Player.Fire1);
            _inputs.Add(InputType.Fire2, _inputActions.Player.Fire2);
            _inputs.Add(InputType.Fire3, _inputActions.Player.Fire3);
        }
    }
    public enum InputType
    {
        Move,
        Fire1,
        Fire2,
        Fire3
    }
}
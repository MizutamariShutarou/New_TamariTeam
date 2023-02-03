using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// ���[�U�[����̓��͂𐧌䂷��N���X
    /// </summary>
    public class InputManager
    {
        private GameController _inputActions = null;
        private Dictionary<InputType, InputAction> _inputs = new Dictionary<InputType, InputAction>();
        private Dictionary<InputType, bool> _isPressed = new Dictionary<InputType, bool>();
        private Dictionary<InputType, bool> _isExist = new Dictionary<InputType, bool>();
        private Dictionary<InputType, bool> _isReleased = new Dictionary<InputType, bool>();
        /// <summary>
        /// ����̃{�^���̌��݂̒l��ۑ�����Dictionary�B
        /// GetValue()�Œl���擾�\�B
        /// </summary>
        private Dictionary<InputType, object> _inputValues = new Dictionary<InputType, object>();

        /// <summary>
        /// ����̃{�^�������������Ƃ���true��Ԃ��f�B�N�V���i��
        /// </summary>
        public Dictionary<InputType, bool> IsPressed => _isPressed;
        /// <summary>
        /// ����̃{�^����������, true��Ԃ��f�B�N�V���i��
        /// </summary>
        public Dictionary<InputType, bool> IsExist => _isExist;
        /// <summary>
        /// ����̃{�^�����J�������Ƃ���true��Ԃ��f�B�N�V���i��
        /// </summary>
        public Dictionary<InputType, bool> IsReleased => _isReleased;

        /// <summary> ���̃N���X�̏��������� </summary>
        public void Init()
        {
            // InputSystem���擾��,�N������B
            _inputActions = new GameController(); // �R���X�g���N�^��InputSystem�N���X�̃C���X�^���X���m�ۂ��悤�Ǝv������{��ꂽ�B�ǂ��ɂ��Ȃ��̂��˂���B
            _inputActions.Enable();
            InputActionInit();
        }

        /// <summary>
        /// ���͂������������Ɏ��s���鏈����"�o�^"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started += inputAction;
        }
        /// <summary>
        /// ���͂��������Ă���ԁA���s���鏈����"�o�^"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed += inputAction;
        }
        /// <summary>
        /// ���͂��Ȃ��Ȃ������Ɏ��s���鏈����"�o�^"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void AddInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled += inputAction;
        }

        /// <summary>
        /// ���͂������������Ɏ��s���鏈����"����"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started -= inputAction;
        }
        /// <summary>
        /// ���͂��������Ă���ԁA���s���鏈����"����"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed -= inputAction;
        }
        /// <summary>
        /// ���͂��Ȃ��Ȃ������Ɏ��s���鏈����"����"����
        /// </summary>
        /// <param name="type"> ���͂̎�� </param>
        /// <param name="inputAction"> ���s���郁�\�b�h </param>
        public void RemoveInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled -= inputAction;
        }
        public T GetValue<T>(InputType type)
        {
            try
            {
                return (T)_inputValues[type];
            }
            catch (InvalidCastException e)
            {
                Debug.LogError($"�L���X�g�Ɏ��s���܂����I\n" + e.ToString());
                return (T)default;
            }
        }
        /// <summary>
        /// Dictionary����������
        /// </summary>
        private void InputActionInit()
        {
            // =========== �f�B�N�V���i���̏��������� =========== //
            _inputs.Add(InputType.Move, _inputActions.Player.Move);
            _inputs.Add(InputType.Fire1, _inputActions.Player.Fire1);
            _inputs.Add(InputType.Fire2, _inputActions.Player.Fire2);
            _inputs.Add(InputType.Fire3, _inputActions.Player.Fire3);

            _isPressed.Add(InputType.Move, false);
            _isPressed.Add(InputType.Fire1, false);
            _isPressed.Add(InputType.Fire2, false);
            _isPressed.Add(InputType.Fire3, false);

            _isExist.Add(InputType.Move, false);
            _isExist.Add(InputType.Fire1, false);
            _isExist.Add(InputType.Fire2, false);
            _isExist.Add(InputType.Fire3, false);

            _isReleased.Add(InputType.Move, false);
            _isReleased.Add(InputType.Fire1, false);
            _isReleased.Add(InputType.Fire2, false);
            _isReleased.Add(InputType.Fire3, false);

            // =========== �������̂�Dictionary��true��Ԃ��悤�ɂ��鏈����o�^ =========== //
            _inputActions.Player.Move.started += async _ =>
            {
                _isPressed[InputType.Move] = true;
                await UniTask.DelayFrame(1);
                _isPressed[InputType.Move] = false;
            };
            _inputActions.Player.Fire1.started += async _ =>
            {
                _isPressed[InputType.Fire1] = true;
                await UniTask.DelayFrame(1);
                _isPressed[InputType.Fire1] = false;
            };
            _inputActions.Player.Fire2.started += async _ =>
             {
                 _isPressed[InputType.Fire2] = true;
                 await UniTask.DelayFrame(1);
                 _isPressed[InputType.Fire2] = false;
             };
            _inputActions.Player.Fire3.started += async _ =>
             {
                 _isPressed[InputType.Fire3] = true;
                 await UniTask.DelayFrame(1);
                 _isPressed[InputType.Fire3] = false;
             };

            // =========== ��������Dictionary��true��Ԃ��悤�ɂ��鏈����o�^ =========== //
            _inputActions.Player.Move.started += _ => _isExist[InputType.Move] = true;
            _inputActions.Player.Fire1.started += _ => _isExist[InputType.Fire1] = true;
            _inputActions.Player.Fire2.started += _ => _isExist[InputType.Fire2] = true;
            _inputActions.Player.Fire3.started += _ => _isExist[InputType.Fire3] = true;

            _inputActions.Player.Move.canceled += _ => _isExist[InputType.Move] = false;
            _inputActions.Player.Fire1.canceled += _ => _isExist[InputType.Fire1] = false;
            _inputActions.Player.Fire2.canceled += _ => _isExist[InputType.Fire2] = false;
            _inputActions.Player.Fire3.canceled += _ => _isExist[InputType.Fire3] = false;

            // =========== �{�^���������Dictionary��true��Ԃ��悤�ɂ��鏈����o�^ =========== //
            _inputActions.Player.Move.canceled += async _ =>
             {
                 _isReleased[InputType.Move] = true;
                 await UniTask.DelayFrame(1);
                 _isReleased[InputType.Move] = false;
             };
            _inputActions.Player.Fire1.canceled += async _ =>
            {
                _isReleased[InputType.Fire1] = true;
                await UniTask.DelayFrame(1);
                _isReleased[InputType.Fire1] = false;
            };
            _inputActions.Player.Fire2.canceled += async _ =>
             {
                 _isReleased[InputType.Fire2] = true;
                 await UniTask.DelayFrame(1);
                 _isReleased[InputType.Fire2] = false;
             };
            _inputActions.Player.Move.canceled += async _ =>
             {
                 _isReleased[InputType.Fire3] = true;
                 await UniTask.DelayFrame(1);
                 _isReleased[InputType.Fire3] = false;
             };

            // =========== �l�ۑ��p��Dictionary�̃Z�b�g�A�b�v =========== //
            _inputValues.Add(InputType.Move, Vector2.zero);
            _inputValues.Add(InputType.Fire1, 0f);
            _inputValues.Add(InputType.Fire2, 0f);
            _inputValues.Add(InputType.Fire3, 0f);

            _inputActions.Player.Move.started +=
                context => _inputValues[InputType.Move] = context.ReadValue<Vector2>();
            _inputActions.Player.Fire1.started +=
                context => _inputValues[InputType.Fire1] = context.ReadValue<float>();
            _inputActions.Player.Fire2.started +=
                context => _inputValues[InputType.Fire2] = context.ReadValue<float>();
            _inputActions.Player.Fire3.started +=
                context => _inputValues[InputType.Fire3] = context.ReadValue<float>();

            _inputActions.Player.Move.performed +=
                context => _inputValues[InputType.Move] = context.ReadValue<Vector2>();
            _inputActions.Player.Fire1.performed +=
                context => _inputValues[InputType.Fire1] = context.ReadValue<float>();
            _inputActions.Player.Fire2.performed +=
                context => _inputValues[InputType.Fire2] = context.ReadValue<float>();
            _inputActions.Player.Fire3.performed +=
                context => _inputValues[InputType.Fire3] = context.ReadValue<float>();

            _inputActions.Player.Move.canceled +=
                context => _inputValues[InputType.Move] = context.ReadValue<Vector2>();
            _inputActions.Player.Fire1.canceled +=
                context => _inputValues[InputType.Fire1] = context.ReadValue<float>();
            _inputActions.Player.Fire2.canceled +=
                context => _inputValues[InputType.Fire2] = context.ReadValue<float>();
            _inputActions.Player.Fire3.canceled +=
                context => _inputValues[InputType.Fire3] = context.ReadValue<float>();
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
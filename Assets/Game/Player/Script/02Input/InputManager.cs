using Cysharp.Threading.Tasks;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// ユーザーからの入力を制御するクラス
    /// </summary>
    public class InputManager
    {
        private GameController _inputActions = null;
        private Dictionary<InputType, InputAction> _inputs = new Dictionary<InputType, InputAction>();
        private Dictionary<InputType, bool> _isPressed = new Dictionary<InputType, bool>();
        private Dictionary<InputType, bool> _isExist = new Dictionary<InputType, bool>();
        private Dictionary<InputType, bool> _isReleased = new Dictionary<InputType, bool>();
        /// <summary>
        /// 特手のボタンの現在の値を保存するDictionary。
        /// GetValue()で値を取得可能。
        /// </summary>
        private Dictionary<InputType, object> _inputValues = new Dictionary<InputType, object>();

        /// <summary>
        /// 特定のボタンを押下したときにtrueを返すディクショナリ
        /// </summary>
        public Dictionary<InputType, bool> IsPressed => _isPressed;
        /// <summary>
        /// 特定のボタンを押下中, trueを返すディクショナリ
        /// </summary>
        public Dictionary<InputType, bool> IsExist => _isExist;
        /// <summary>
        /// 特定のボタンを開放したときにtrueを返すディクショナリ
        /// </summary>
        public Dictionary<InputType, bool> IsReleased => _isReleased;

        /// <summary> このクラスの初期化処理 </summary>
        public void Init()
        {
            // InputSystemを取得し,起動する。
            _inputActions = new GameController(); // コンストラクタでInputSystemクラスのインスタンスを確保しようと思ったら怒られた。どうにかならんのかねこれ。
            _inputActions.Enable();
            InputActionInit();
        }

        /// <summary>
        /// 入力が発生した時に実行する処理を"登録"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started += inputAction;
        }
        /// <summary>
        /// 入力が発生している間、実行する処理を"登録"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed += inputAction;
        }
        /// <summary>
        /// 入力がなくなった時に実行する処理を"登録"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled += inputAction;
        }

        /// <summary>
        /// 入力が発生した時に実行する処理を"解除"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void RemoveInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started -= inputAction;
        }
        /// <summary>
        /// 入力が発生している間、実行する処理を"解除"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void RemoveInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed -= inputAction;
        }
        /// <summary>
        /// 入力がなくなった時に実行する処理を"解除"する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
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
                Debug.LogError($"キャストに失敗しました！\n" + e.ToString());
                return (T)default;
            }
        }
        /// <summary>
        /// Dictionary初期化処理
        /// </summary>
        private void InputActionInit()
        {
            // =========== ディクショナリの初期化処理 =========== //
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

            // =========== 押下時のみDictionaryがtrueを返すようにする処理を登録 =========== //
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

            // =========== 押下中にDictionaryがtrueを返すようにする処理を登録 =========== //
            _inputActions.Player.Move.started += _ => _isExist[InputType.Move] = true;
            _inputActions.Player.Fire1.started += _ => _isExist[InputType.Fire1] = true;
            _inputActions.Player.Fire2.started += _ => _isExist[InputType.Fire2] = true;
            _inputActions.Player.Fire3.started += _ => _isExist[InputType.Fire3] = true;

            _inputActions.Player.Move.canceled += _ => _isExist[InputType.Move] = false;
            _inputActions.Player.Fire1.canceled += _ => _isExist[InputType.Fire1] = false;
            _inputActions.Player.Fire2.canceled += _ => _isExist[InputType.Fire2] = false;
            _inputActions.Player.Fire3.canceled += _ => _isExist[InputType.Fire3] = false;

            // =========== ボタン解放時にDictionaryがtrueを返すようにする処理を登録 =========== //
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

            // =========== 値保存用のDictionaryのセットアップ =========== //
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
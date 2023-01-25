using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    /// <summary>
    /// ユーザーからの入力を制御するクラス
    /// </summary>
    public class Input
    {
        private GameController _inputActions = null;
        public GameController InputActions => _inputActions;
        private Dictionary<InputType, InputAction> _inputs = new Dictionary<InputType, InputAction>();

        /// <summary> このクラスの初期化処理 </summary>
        public void Init()
        {
            // InputSystemを取得し,起動する。
            _inputActions = new GameController();
            _inputActions.Enable();
            InputActionInit();
        }

        /// <summary>
        /// 入力が発生した時に実行する処理を登録する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started += inputAction;
        }
        /// <summary>
        /// 入力が発生している間、実行する処理を登録する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed += inputAction;
        }
        /// <summary>
        /// 入力がなくなった時に実行する処理を登録する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void AddInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled += inputAction;
        }

        /// <summary>
        /// 入力が発生した時に実行する処理を解除する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void RemoveInputEnter(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].started -= inputAction;
        }
        /// <summary>
        /// 入力が発生している間、実行する処理を解除する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void RemoveInputStay(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].performed -= inputAction;
        }
        /// <summary>
        /// 入力がなくなった時に実行する処理を解除する
        /// </summary>
        /// <param name="type"> 入力の種類 </param>
        /// <param name="inputAction"> 実行するメソッド </param>
        public void RemoveInputExit(InputType type, System.Action<InputAction.CallbackContext> inputAction)
        {
            _inputs[type].canceled -= inputAction;
        }
        /// <summary>
        /// Dictionary初期化処理
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
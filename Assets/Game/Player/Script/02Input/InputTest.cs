using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;
using UnityEngine.InputSystem;

public class InputTest : MonoBehaviour
{
    private InputManager _inputManager = new InputManager();

    private void Start()
    {
        _inputManager.Init();
    }

    private void Update()
    {
        // いずれかのキーが押下されたときに実行する
        //if (Keyboard.current.anyKey.wasPressedThisFrame)
        //{
        OutputValue();
        //}
    }
    /// <summary>
    /// InputManagerのフィールドの状態をコンソールに出力する。
    /// </summary>
    private void OutputValue()
    {

    }
}

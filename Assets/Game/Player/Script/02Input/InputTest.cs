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
        // �����ꂩ�̃L�[���������ꂽ�Ƃ��Ɏ��s����
        //if (Keyboard.current.anyKey.wasPressedThisFrame)
        //{
        OutputValue();
        //}
    }
    /// <summary>
    /// InputManager�̃t�B�[���h�̏�Ԃ��R���\�[���ɏo�͂���B
    /// </summary>
    private void OutputValue()
    {

    }
}

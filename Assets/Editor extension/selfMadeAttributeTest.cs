using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class selfMadeAttributeTest : MonoBehaviour
{
    [InputName, SerializeField]
    private string _inputNameTest = default;
    [SceneName, SerializeField]
    private string _sceneNameTest = default;
    [TagName, SerializeField]
    private string _tagNameTest = default;
    [AnimationParameter, SerializeField]
    private string _animationParameterTest = default;
}
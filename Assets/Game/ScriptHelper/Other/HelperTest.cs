using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    public class HelperTest : MonoBehaviour
    {
        [SerializeField]
        private OverlapBox2D _overlapBox2DSample = default;
        [SerializeField]
        private Raycast2D _raycast2DSample = default;

        private void Start()
        {
            //できれば Init(), Update(),OnDrawGizmos() を記述しなくて済むような機構を作りたい。
            _overlapBox2DSample.Init(transform);
            _raycast2DSample.Init(transform);
        }
        private void Update()
        {
            _overlapBox2DSample.Update();
            _raycast2DSample.Updaet();
        }
        private void OnDrawGizmos()
        {
            _overlapBox2DSample.OnDrawGizmos(transform);
            _raycast2DSample.OnDrawGizmo(transform);
        }
    }
}

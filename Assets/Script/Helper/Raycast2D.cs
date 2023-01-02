using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Helper
{
    [System.Serializable]
    public class Raycast2D
    {
        [SerializeField]
        private Vector2 _dir = default;
        [SerializeField]
        private float _maxDistance = default;
        [SerializeField]
        private LayerMask _targetLayer = default;

        private Transform _origin = null;
        private Vector2 _previousPos = default;
        private RaycastHit2D _result = default;
        private float _horizontalDirection = 1f;

        public Vector2 Dir => _dir;
        public float MaxDistance => _maxDistance;
        public LayerMask TargetLayer => _targetLayer;
        private RaycastHit2D Result => _result;

        public void Init(Transform origin)
        {
            _origin = origin;
        }
        public void Updaet()
        {
            var diff = _previousPos.x - _origin.position.x;
            if (Mathf.Abs(diff) > 0.01f)
            {
                _horizontalDirection = diff < 0f ? 1f : -1f;
            }
            _previousPos = _origin.position;
        }

        public bool GetResultBoolean()
        {
            return Physics2D.Raycast(
                _origin.position,
                new Vector2(_dir.x * _horizontalDirection, _dir.y),
                _maxDistance,
                _targetLayer);
        }
        public RaycastHit2D GetResultRaycast2D()
        {
            return Physics2D.Raycast(
                _origin.position,
                new Vector2(_dir.x * _horizontalDirection, _dir.y),
                _maxDistance,
                _targetLayer);
        }
        [Header("DrawGizmo")]
        [SerializeField]
        private Color _hitColor = Color.blue;
        [SerializeField]
        private Color _noHitColor = Color.red;

        public void OnDrawGizmo(Transform origin)
        {
            // Ray���q�b�g�����ꍇ�ŐF��ς���B
            RaycastHit2D hit;
            if (hit = Physics2D.Raycast(
                origin.position,
                new Vector2(_dir.x * _horizontalDirection, _dir.y),
                _maxDistance,
                _targetLayer))
            {
                //�Փˎ���Ray����ʂɕ\��
                Debug.DrawRay(
                    origin.position, // �J�n�ʒu
                    (Vector3)hit.point - origin.position, //Ray�̕����Ƌ���
                    _hitColor, // �q�b�g�����ꍇ�̐F
                    0, // �ΏۂƂȂ郌�C���[
                    false); // ���C�����J��������߂��I�u�W�F�N�g�ɂ���ĉB���ꂽ�ꍇ�Ƀ��C�����B�����ǂ���
                return;
            }

            //��Փˎ���Ray����ʂɕ\��
            Debug.DrawRay(
                origin.position,
                new Vector2(_dir.x * _horizontalDirection, _dir.y).normalized * _maxDistance,
                _noHitColor,
                0,
                false);
        }
    }
}

using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [System.Serializable]
    public class Jump
    {
        [SerializeField]
        private float _jumpPower = 1f;
        [SerializeField]
        private Helper.OverlapBox2D _groundChecker = default;

        private Rigidbody2D _rigidbody2D = null;

        public Helper.OverlapBox2D GroundChecker => _groundChecker;

        public void Init(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
            _groundChecker.Init(rigidbody2D.transform);
        }
        public void OnJump(InputAction.CallbackContext _)
        {
            if (_groundChecker.IsHit())
            {
                _rigidbody2D.velocity = new Vector2(
                    _rigidbody2D.velocity.x,
                    _jumpPower
                    );
            }
        }
    }
}
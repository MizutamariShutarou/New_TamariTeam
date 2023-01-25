using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [System.Serializable]
    public class Move
    {
        [SerializeField]
        private float _moveSpeed = 1f;

        private float _horizontalInput = default;
        private Rigidbody2D _rigidbody2D = null;

        public void Init(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void OnMovementControl(InputAction.CallbackContext callbackContext)
        {
            // “ü—Í‚ğæ“¾‚·‚é
            _horizontalInput = callbackContext.ReadValue<Vector2>().x;
        }
        public void EndMovementControl(InputAction.CallbackContext _)
        {
            // ‘¬“x‚ğÁ‚·
            _horizontalInput = 0f;
        }
        public void Update()
        {
            // Rigidbody2D‚É‘¬“x‚ğ“n‚·
            _rigidbody2D.velocity = new Vector2(
                _horizontalInput * _moveSpeed,
                _rigidbody2D.velocity.y
                );
        }
    }
}
using MyBlueThing.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Movements
{
    public class JumpMulti : IJump
    {
        IOnGround _onGround;
        Rigidbody2D _rigidBody;
        
        float _jumpForce = 600f;
        int _maxJumpCount = 2;
        int _currentJumpCount = 0;

        public bool IsJump { get; set; }

        public JumpMulti(Rigidbody2D rigidbody, IOnGround onGround)
        {
            _rigidBody = rigidbody;
            _onGround = onGround;
        }

        public void TickWithFixedUpdate()
        {
            if(IsJump)
            {
                if (_currentJumpCount < _maxJumpCount)
                {
                    _rigidBody.velocity = Vector2.zero;
                    _rigidBody.AddForce(Vector2.up * _jumpForce);
                    _rigidBody.velocity = Vector2.zero;
                    _currentJumpCount++;
                }
                else if(_onGround.IsGround)
                {
                    IsJump = false;
                    _currentJumpCount = 0;
                }
            }         
        }
    }
}


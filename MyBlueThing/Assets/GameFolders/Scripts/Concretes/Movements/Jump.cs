using MyBlueThing.Abstracts.Movements;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Movements
{
    public class Jump : IJump
    {
        Rigidbody2D _rigidBody;
        IOnGround _onGround;

        float _jumpForce = 800f;

        public bool IsJump { get; set; }

        public Jump(Rigidbody2D rigidBody, IOnGround onGround)
        {
            _rigidBody = rigidBody;
            _onGround = onGround;
        }

        public void TickWithFixedUpdate()
        {
            if(IsJump && _onGround.IsGround)
            {
                _rigidBody.velocity = Vector2.zero;
                _rigidBody.AddForce(Vector2.up * _jumpForce);
                _rigidBody.velocity = Vector2.zero;
            }
            IsJump = false;
        }
    }
}


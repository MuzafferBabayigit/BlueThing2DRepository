using MyBlueThing.Abstracts.Animations;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Animations
{
    public class PlayerAnimation : IAnimation
    {
        Animator _animator;
        public PlayerAnimation(Animator animator)
        {
            _animator = animator;
        }

        public void JumpAnimation(bool isJump)
        {
            if (_animator.GetBool("isJump") == isJump) return;
            _animator.SetBool("isJump", isJump);
        }

        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
        }
    }
}


using MyBlueThing.Abstracts.Movements;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Movements
{
    public class FlipWithSprite : IFlip
    {
        SpriteRenderer _spriteRenderer;
        public FlipWithSprite(PlayerController player)
        {
            _spriteRenderer = player.GetComponentInChildren<SpriteRenderer>();
        }
        public void FlipCharacter(float direction)
        {
            if (direction == 0f) return;

            if(direction < 0f)
            {
                _spriteRenderer.flipX = true;
            }
            else
            {
                _spriteRenderer.flipX = false;
            }
        }
    }
}


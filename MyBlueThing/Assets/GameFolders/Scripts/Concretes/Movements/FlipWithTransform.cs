using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Abstracts.Movements;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Movements
{
    public class FlipWithTransform : IFlip
    {
        IEntityController _entity;

        public FlipWithTransform(IEntityController entity)
        {
            _entity = entity;
        }
        public void FlipCharacter(float direction)
        {
            if (direction == 0) return;

            float mathValue = Mathf.Sign(direction);

            if(mathValue != _entity.transform.localScale.x)
            {
                _entity.transform.localScale = new Vector2(mathValue, 1f);
            }
        }
    }
}

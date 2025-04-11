using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Abstracts.Movements;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Movements
{
    public class Mover : MonoBehaviour, IMover
    {
        IEntityController _controller;
        float _moveSpeed;
        public Mover(IEntityController controller, float moveSpeed)
        {
            _controller = controller;
            _moveSpeed = moveSpeed;
        }

        public void Tick(float horizontal)
        {
            if (horizontal == 0f) return;
            _controller.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
        }
    }
}


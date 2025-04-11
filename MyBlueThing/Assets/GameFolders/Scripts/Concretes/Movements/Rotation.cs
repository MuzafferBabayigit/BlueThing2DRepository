using MyBlueThing.Abstracts.Movements;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace MyBlueThing.Movements
{
    public class Rotation : MonoBehaviour
    {
        [SerializeField] float rotationSpeed = 100.0f;

        private void FixedUpdate()
        {
            transform.Rotate(0,0,rotationSpeed * Time.deltaTime);
        }
    }
}


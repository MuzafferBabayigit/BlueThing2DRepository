using MyBlueThing.Abstracts.Inputs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace MyBlueThing.Inputs
{
    public class MobileInput : IPlayerInput
    {
        public float Horizontal => CrossPlatformInputManager.GetAxis("Horizontal");

        public float Vertical => CrossPlatformInputManager.GetAxis("Vertical");

        public bool JumpButtonDown => CrossPlatformInputManager.GetButtonDown("Jump");
    }
}


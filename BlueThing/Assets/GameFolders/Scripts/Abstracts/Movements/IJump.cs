using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Abstracts.Movements
{
    public interface IJump
    {
        void TickWithFixedUpdate();
        public bool IsJump { get; set; }
    }
}

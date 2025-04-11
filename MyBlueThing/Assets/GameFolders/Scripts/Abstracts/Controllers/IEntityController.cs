using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Abstracts.Controllers
{
    public interface IEntityController
    {
        Transform transform { get; }
    }
}


using MyBlueThing.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Extensions
{
    public static class ExtensionMethods
    {
        public static DecreaseHealth ObjectHasHealth(this Collision2D collision)
        {
            DecreaseHealth health = collision.collider.GetComponent<DecreaseHealth>();

            if (health != null)
            {
                return health;
            }

            return null;
        }
    }
}


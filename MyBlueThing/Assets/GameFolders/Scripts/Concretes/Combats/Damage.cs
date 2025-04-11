using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Combats
{
    public class Damage : MonoBehaviour
    {
        [SerializeField] int damage = 1;
        
        public int HitDamage => damage;

        public void HitTarget(DecreaseHealth playerHealth)
        {
            playerHealth.TakeHit(this);
        }
    }
}


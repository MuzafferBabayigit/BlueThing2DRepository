using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Combats
{
    public class Heal : MonoBehaviour
    {
        [SerializeField] int heal = 1;

        public int TakedHeal => heal;

        public void HitHeal(DecreaseHealth playerHealth)
        {
            playerHealth.TakeHeal(this);
        }
    }
}


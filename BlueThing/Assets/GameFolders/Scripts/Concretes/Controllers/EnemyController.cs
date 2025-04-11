using MyBlueThing.Combats;
using MyBlueThing.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class EnemyController : MonoBehaviour
    {
        Damage damage;
        GameObject startObject;

        private void Awake()
        {
            damage = GetComponent<Damage>();
            startObject = GameObject.FindGameObjectWithTag("StartObjectTag");
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DecreaseHealth playerHealth = collision.ObjectHasHealth();

            if (playerHealth != null)
            {
                playerHealth.TakeHit(damage);
                playerHealth.transform.position = startObject.transform.position;
            }
        }
    }
}


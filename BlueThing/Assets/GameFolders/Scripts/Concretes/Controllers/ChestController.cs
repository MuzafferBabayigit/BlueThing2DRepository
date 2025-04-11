using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Combats;
using MyBlueThing.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class ChestController : MonoBehaviour
    {
        [SerializeField] float chestRadius = 5f;

        Heal heal;
        Animator animator;
        AudioSource audioSource;
        Collider2D chestCollider;
        IEntityController player;
        
        private void Awake()
        {
            heal = GetComponent<Heal>();
            player = FindAnyObjectByType<PlayerController>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            chestCollider = GetComponent<Collider2D>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if (distance < chestRadius)
            {
                animator.SetTrigger("checkTrigger");
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            DecreaseHealth playerHealth = collision.ObjectHasHealth();
            if (playerHealth != null && playerHealth.CurrentHealth < 3)
            {
                playerHealth.TakeHeal(heal);
                audioSource.Play();
                animator.SetTrigger("chestLightClose");
                chestCollider.enabled = false;
            }
        }
    }
}


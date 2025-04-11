using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class SpokController : MonoBehaviour
    {
        [SerializeField] float wakeRadius = 10f;

        IEntityController player;
        Animator animator;
        Rigidbody2D rigidBody;

        private void Awake()
        {
            rigidBody = GetComponent<Rigidbody2D>();
            animator = GetComponentInChildren<Animator>();
            player = FindAnyObjectByType<PlayerController>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(transform.position, player.transform.position);

            if(distance < wakeRadius)
            {
                rigidBody.bodyType = RigidbodyType2D.Dynamic;
                animator.SetTrigger("spokWakeUp");
            }
        }
    }
}


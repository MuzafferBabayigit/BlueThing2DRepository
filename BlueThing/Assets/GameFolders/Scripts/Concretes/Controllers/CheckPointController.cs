using MyBlueThing.Combats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class CheckPointController : MonoBehaviour
    {
        Animator animator;
        AudioSource audioSource;
        GameObject startObject;
        Collider2D collider;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
            collider = GetComponent<Collider2D>();
            startObject = GameObject.FindGameObjectWithTag("StartObjectTag");
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.GetComponent<PlayerController>() != null)
            {
                audioSource.Play();
                animator.SetTrigger("checkTrigger");
                startObject.transform.position = this.transform.position;
                collider.enabled = false;
            }
        }
    }
}


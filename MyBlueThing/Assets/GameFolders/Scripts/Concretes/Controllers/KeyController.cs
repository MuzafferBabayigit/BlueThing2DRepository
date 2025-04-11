using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class KeyController : MonoBehaviour
    {
        [SerializeField] Transform transformGate;

        AudioSource audioSource;
        Collider2D collider;

        int keyCount = 1;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            collider = GetComponent<Collider2D>();
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {           
            if (collision.GetComponent<PlayerController>() != null)
            {
                audioSource.Play();
                GameManager.Instance.IncreaseKey(keyCount);
                transform.position = transformGate.position;
                collider.enabled = false;
            }
        }
    }
}


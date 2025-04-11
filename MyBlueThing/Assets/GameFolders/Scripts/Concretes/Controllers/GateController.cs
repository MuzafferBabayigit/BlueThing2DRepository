using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Managers;
using MyBlueThing.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class GateController : MonoBehaviour
    {
        [SerializeField] float wakeRadius = 7f;

        Animator animator;
        Collider2D collider;
        AudioSource audioSource;
        IEntityController player;

        float distance;
        int keyCount;

        private void Awake()
        {
            collider = GetComponent<Collider2D>();
            animator = GetComponent<Animator>();
            player = FindAnyObjectByType<PlayerController>();
            audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            GameManager.Instance.keyCount = 0;
        }

        private void Update()
        {
            this.keyCount = GameManager.Instance.keyCount;
            distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < wakeRadius && keyCount == 2)
            {
                animator.SetTrigger("checkTrigger");
                collider.enabled = true;
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();
            if (collision.GetComponent<PlayerController>() != null)
            {
                gameCanvas.ShowNextLevelPanel();
                audioSource.Play();
            }
        }



        //key say�s�n� g�ncel takip edilemedi�i i�in start methodu i�inde yaz�lmas� gerekiyordu.
        //Handle de�il gamemanagerden direkt public olarak ula��p start i�inde s�f�rlayabildim.
        /*
        private void OnEnable()
        {
            GameManager.Instance.OnKeyChanged += HandleOnKeyChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnKeyChanged -= HandleOnKeyChanged;
        }

        private void HandleOnKeyChanged(int keyCount)
        {
            this.keyCount = keyCount;
        }*/
    }
}


using MyBlueThing.Abstracts.Animations;
using MyBlueThing.Abstracts.Controllers;
using MyBlueThing.Abstracts.Inputs;
using MyBlueThing.Abstracts.Movements;
using MyBlueThing.Animations;
using MyBlueThing.Combats;
using MyBlueThing.Inputs;
using MyBlueThing.Movements;
using MyBlueThing.Uis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Controllers
{
    public class PlayerController : MonoBehaviour, IEntityController
    {
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] AudioClip deadClip;

        float _horizontal;

        IPlayerInput _input;
        IMover _mover;
        IAnimation _animation;
        IFlip _flip;
        IJump _jump;
        IOnGround _onGround;
        DecreaseHealth _decreaseHealth;
        AudioSource _audioSource;

        public static event System.Action<AudioClip> OnPlayerDead;

        private void Awake()
        {
            _input = new MobileInput();
            _mover = new Mover(this, moveSpeed);
            _animation = new PlayerAnimation(GetComponent<Animator>());
            _flip = new FlipWithTransform(this);
            _onGround = GetComponent<IOnGround>();
            _jump = new Jump(GetComponent<Rigidbody2D>(), _onGround);
            _decreaseHealth = GetComponent<DecreaseHealth>();
            _audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            GameCanvas gameCanvas = FindObjectOfType<GameCanvas>();

            if (gameCanvas != null)
            {
                _decreaseHealth.onDead += gameCanvas.ShowGameOverPanel;
                DisplayHealth displayHealth = gameCanvas.GetComponentInChildren<DisplayHealth>();
                _decreaseHealth.OnHealthDecrease += displayHealth.WriteHealth;
                _decreaseHealth.OnHealthIncrease += displayHealth.WriteHealth;
            }

            _decreaseHealth.onDead += () => OnPlayerDead.Invoke(deadClip);
            _decreaseHealth.OnHealthDecrease += PlayOnTakeHit;
        }

        private void Update()
        {
            _horizontal = _input.Horizontal;

            if (_input.JumpButtonDown)
            {
                _jump.IsJump = true;
            }

            _animation.JumpAnimation(!_onGround.IsGround);
            _animation.MoveAnimation(_horizontal);
        }

        private void FixedUpdate()
        {
            if (_decreaseHealth.IsDead) return;

            _flip.FlipCharacter(_horizontal);
            _mover.Tick(_horizontal);
            _jump.TickWithFixedUpdate();
        }

        private void PlayOnTakeHit(int currentHealth, int maxHealth)
        {
            if (currentHealth == maxHealth) return;
            _audioSource.Play();
        }
    }
}


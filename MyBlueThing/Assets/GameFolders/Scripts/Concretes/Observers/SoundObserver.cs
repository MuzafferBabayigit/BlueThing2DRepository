using MyBlueThing.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Observers
{
    public class SoundObserver : MonoBehaviour
    {
        AudioSource audioSource;

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        private void OnEnable()
        {
            PlayerController.OnPlayerDead += PlaySoundOneShot;
        }

        private void OnDisable()
        {
            PlayerController.OnPlayerDead -= PlaySoundOneShot;
        }

        private void PlaySoundOneShot(AudioClip audioClip)
        {
            audioSource.PlayOneShot(audioClip);
        }
    }
}


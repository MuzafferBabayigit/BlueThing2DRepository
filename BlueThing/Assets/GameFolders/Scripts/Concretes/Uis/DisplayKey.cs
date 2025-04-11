using MyBlueThing.Controllers;
using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class DisplayKey : MonoBehaviour
    {
        TextMeshProUGUI _keyText;

        private void Awake()
        {
            _keyText = GetComponent<TextMeshProUGUI>();
        }

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
            _keyText.text = keyCount.ToString();
        }
    }
}


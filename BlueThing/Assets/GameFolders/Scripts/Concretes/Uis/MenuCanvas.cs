using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class MenuCanvas : MonoBehaviour
    {
        [SerializeField] MenuPanel menuPanel;

        private void OnEnable()
        {
            GameManager.Instance.OnSceneChanged += HandleSceneChanged;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;
        }

        private void HandleSceneChanged(bool isActive)
        {
            if (isActive == menuPanel.gameObject.activeSelf) return;
            menuPanel.gameObject.SetActive(isActive);
        }
    }
}


using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MyBlueThing.Uis
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gamePanel;
        [SerializeField] GameObject gameOverPanel;
        [SerializeField] GameObject nextlevelPanel;

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
            if (!isActive == gamePanel.activeSelf) return;
            gamePanel.SetActive(!isActive);
        }

        public void ShowGameOverPanel()
        {
            gameOverPanel.SetActive(true);
        }

        public void ShowNextLevelPanel()
        {
            nextlevelPanel.SetActive(true);
        }
    }
}


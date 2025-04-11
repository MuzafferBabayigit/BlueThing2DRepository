using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class NextLevelPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI _sceneText;

        private void OnEnable()
        {
            int sceneIndex = PlayerPrefs.GetInt("activeScene");
            _sceneText.text = "COMPLETED " + sceneIndex +". LEVEL";
        }

        public void NextLevel()
        {
            GameManager.Instance.LoadScene(1);
            this.gameObject.SetActive(false);
        }

        public void QuitGame()
        {
            GameManager.Instance.LoadMenuAndUI(1f);
        }
    }
}


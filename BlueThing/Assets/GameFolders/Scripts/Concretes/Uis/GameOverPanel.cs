using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        public void RestartGame()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void QuitGame()
        {
            GameManager.Instance.LoadMenuAndUI(1f);
        }
    }
}


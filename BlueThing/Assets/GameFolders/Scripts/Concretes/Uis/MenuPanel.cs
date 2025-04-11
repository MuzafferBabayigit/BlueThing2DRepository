using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBlueThing.Uis
{
    public class MenuPanel : MonoBehaviour
    {
        [SerializeField] DeleteSavePanel deleteSavePanel;

        public void StartButtonClicked()
        {
            if (PlayerPrefs.GetInt("activeScene") < 2)
            {
                //SceneManager.LoadScene(2);
                GameManager.Instance.LoadScene(1);
            }
            else
            {
                GameManager.Instance.LoadScene(PlayerPrefs.GetInt("activeScene"));
            }
        }

        public void ExitButtonClicked()
        {
            GameManager.Instance.ExitGame();
        }

        public void CloseMusic(bool muted)
        {
            if (muted)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }

        public void DeleteSaveButton()
        {
            deleteSavePanel.gameObject.SetActive(true);
        }
    }
}


using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class OptionsPanel : MonoBehaviour
    {
        [SerializeField] GameObject backgrounSoundObject;

        public void RestartGame()
        {
            GameManager.Instance.LoadScene();
            this.gameObject.SetActive(false);
        }

        public void CloseMusic(bool muted)
        {
            if(muted)
            {
                AudioListener.volume = 0;
            }
            else
            {
                AudioListener.volume = 1;
            }
        }

        public void ReturnMenu()
        {
            GameManager.Instance.LoadMenuAndUI(1f);
        }
    }
}


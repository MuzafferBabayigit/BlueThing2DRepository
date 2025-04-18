using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBlueThing.Managers
{
    public class GameManager : MonoBehaviour
    {
        public int keyCount = 0;
        public static GameManager Instance { get; private set; }

        public event System.Action<bool> OnSceneChanged;
        public event System.Action<int> OnKeyChanged;

        private void Awake()
        {
            SingletonThisObject();
        }

        private void SingletonThisObject()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void LoadScene(int levelIndex = 0)
        {
            StartCoroutine(LoadSceneAsync(levelIndex));
        }

        private IEnumerator LoadSceneAsync(int levelIndex)
        {
            //yield return new WaitForSeconds(0.2f);

            int buildIndex = SceneManager.GetActiveScene().buildIndex;

            yield return SceneManager.UnloadSceneAsync(buildIndex);

            SceneManager.LoadSceneAsync(buildIndex + levelIndex, LoadSceneMode.Additive).completed += (AsyncOperation obj) =>
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(buildIndex + levelIndex));
            };

            OnSceneChanged?.Invoke(false);
        }

        public void ExitGame()
        {
            Application.Quit();
        }
        
        public void LoadMenuAndUI(float delayLoadingTime)
        {
            StartCoroutine(LoadMenuAndUIAsync(delayLoadingTime));
        }

        private IEnumerator LoadMenuAndUIAsync(float delayLoadingTime)
        {
            yield return new WaitForSeconds(delayLoadingTime);
            yield return SceneManager.LoadSceneAsync("Menu");
            yield return SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);

            OnSceneChanged?.Invoke(true);
        }

        public void IncreaseKey(int keyCount = 0)
        {
            this.keyCount += keyCount;
            OnKeyChanged?.Invoke(this.keyCount);
        }
    }
}


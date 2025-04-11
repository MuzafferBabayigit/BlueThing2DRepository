using MyBlueThing.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class SplashCanvas : MonoBehaviour
    {
        private void Start()
        {
            GameManager.Instance.LoadMenuAndUI(1f);
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class OptionButton : MonoBehaviour
    {
        [SerializeField] GameObject optionsPanel;

        public void OptionsClicked()
        {
            optionsPanel.SetActive(true);
        }
    }
}


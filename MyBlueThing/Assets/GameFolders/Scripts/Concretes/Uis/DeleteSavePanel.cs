using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyBlueThing.Uis
{
    public class DeleteSavePanel : MonoBehaviour
    {
        public void YesButton()
        {
            PlayerPrefs.DeleteAll();
            this.gameObject.SetActive(false);
        }
    }
}


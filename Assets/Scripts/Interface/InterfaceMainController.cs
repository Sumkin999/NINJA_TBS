using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Interface
{
    public class InterfaceMainController:MonoBehaviour
    {
        public Image PauseImage;

        public void PauseImageVisibility(bool isPaused)
        {
            PauseImage.gameObject.SetActive(isPaused);
        }
    }
}

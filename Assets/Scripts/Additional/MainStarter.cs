using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Additional
{
    public class MainStarter:MonoBehaviour
    {
        public Image TutorialImage;
        public Button ContinueButton;
        public Image LogoImage;

        private bool _anyKeyPressed = false;
        public void Method()
        {
            if (!_anyKeyPressed)
            {
                LogoImage.gameObject.SetActive(false);
                TutorialImage.gameObject.SetActive(true);
                ContinueButton.gameObject.SetActive(true);
                _anyKeyPressed = true;
            }
        }

        void Update()
        {
            if (Input.anyKey)
            {
                Method();
            }
        }
    }
}

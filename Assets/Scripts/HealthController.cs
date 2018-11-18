using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthController:MonoBehaviour
    {
        public float Health;
        public Slider Slider;

        void Update()
        {
            Slider.value = Health;
        }
    }
}

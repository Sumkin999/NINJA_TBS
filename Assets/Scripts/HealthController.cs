using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameMechanic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class HealthController:MonoBehaviour
    {
        public Slider Slider;

        void Update()
        {
            Slider.value = Game.PlayerUnit.Health/Game.PlayerUnit.MaxHealth;
        }
    }
}

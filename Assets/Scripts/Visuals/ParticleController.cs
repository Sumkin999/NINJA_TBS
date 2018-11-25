using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Visuals
{
    public class ParticleController:MonoBehaviour
    {
        public ParticleSystem ParticleSystem;
        public float LifeTimer;

        
        void Update()
        {
            if (Game.GameTime.IsOnPause)
            {
                if (!ParticleSystem.isPaused)
                {
                    ParticleSystem.Pause();
                }
            }
            else
            {
                LifeTimer -= Time.deltaTime;
                if (ParticleSystem.isPaused)
                {
                    ParticleSystem.Play();
                }
            }
            
            
            if (LifeTimer<0)
            {
                GameObject.Destroy(this.gameObject);
            }
        }
    }
}

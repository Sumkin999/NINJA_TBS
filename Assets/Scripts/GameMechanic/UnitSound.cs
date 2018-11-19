using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Sound;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class UnitSound:MonoBehaviour
    {
        public GameUnit Unit;

        public SoundComponent WalkSound;
        public SoundComponent SwordHitSound;

        private float _sinceStopTimer = 0;
        public void Update()
        {
            
            if (Unit.IsMoving)
            {
                if (!WalkSound.IsSoundPlaying)
                {
                    WalkSound.Play();
                }
                _sinceStopTimer = 0;
            }
            else
            {
                _sinceStopTimer += Time.deltaTime;

                if (_sinceStopTimer>0.15f)
                {
                    if (WalkSound.IsSoundPlaying)
                    {
                        WalkSound.Stop();
                    }
                }
                
            }
        }

        public void SwordWindSoundPlay()
        {
            SwordHitSound.Play();
        }
    }
}

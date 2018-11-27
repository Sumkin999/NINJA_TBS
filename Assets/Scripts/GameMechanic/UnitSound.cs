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

        public Animator Animator;

        public SoundComponent RightStepSound;
        public SoundComponent LeftStepSound;
        public SoundComponent SwordHitSound;
        public SoundComponent RollWindSound;
        public SoundComponent RollGroundSound;
        public SoundComponent FallOnKneesSound;
        public SoundComponent FallOnGroundSound;
        public SoundComponent HitSoundSoundComponent;

        public void SwordWindSoundPlay()
        {
            SwordHitSound.Play();
        }

        public void RightLegStepSoundPlay()
        {
            RightStepSound.Play();
        }

        public void LeftLegStepSoundPlay()
        {
            LeftStepSound.Play();
        }

        public void StepStopSoundPlay()
        {
            LeftStepSound.Stop();
            RightStepSound.Stop();
            if (Animator==null)
            {
                return;
            }
            Animator.SetFloat("Move", 0);
            Animator.SetFloat("Strafe", 0);
        }

        public void RollWindSoundPlay()
        {
            RollWindSound.Play();
        }

        public void RollGroundSoundPlay()
        {
            RollGroundSound.Play();
        }

        public void FallOnKneesSoundPlay()
        {
            FallOnKneesSound.Play();
        }

        public void FallOnGroundSoundPlay()
        {
            FallOnGroundSound.Play();
        }

        public void HitSoundPlay()
        {
            HitSoundSoundComponent.Play();
        }



    }
}

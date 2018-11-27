using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Visuals.AnimationScripts
{
    public class SoundAnimationEventController:MonoBehaviour
    {
        public UnitSound UnitSound;

        public void Start()
        {
            UnitSound.Animator = this.gameObject.GetComponent<Animator>();
        }

        #region AnimatorEvents
        public void Run_RightLegTouchedGround()
        {
            UnitSound.RightLegStepSoundPlay();
        }

        public void Run_LefthtLegTouchedGround()
        {
            UnitSound.LeftLegStepSoundPlay();
        }

        public void AnimEvent_StopWalk()
        {
            UnitSound.StepStopSoundPlay();
        }

        public void AnimEvent_HitStart()
        {
            UnitSound.SwordWindSoundPlay();
        }

        public void AnimEvent_RightLegTouchedGround()
        {
            UnitSound.RightLegStepSoundPlay();
        }

        public void AnimEvent_RollWind()
        {
            UnitSound.RollWindSoundPlay();
        }

        public void AnimEvent_RollGround()
        {
            UnitSound.RollGroundSoundPlay();
        }

        public void AnimEvent_FallOnKnees()
        {
            UnitSound.FallOnKneesSoundPlay();
        }

        public void AnimEvent_Fall()
        {
            UnitSound.FallOnGroundSoundPlay();
        }

        public void AnimEvent_Hitted()
        {
            UnitSound.HitSoundPlay();
        }

        #endregion

    }
}

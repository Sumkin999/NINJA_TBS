using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.AtomGoals
{
    public class AtomGoalIdle:Goal
    {
        public AtomGoalIdle(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoalClass, float idleTime)
            : base(brain, interestBrain, addGoalClass)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoalClass;

            _idleTimer = idleTime;
        }

        private float _idleTimer;


        public override void Avtivate()
        {
            BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>().CurrentCommand = new IdleCommand(BrainBase.GameUnit);

            GoalState=GoalState.Active;
        }

        public override void UpdateAction()
        {
            if (!Game.GameTime.IsOnPause)
            {
                _idleTimer -= Time.deltaTime;
            }
            if (_idleTimer<0)
            {
                GoalState=GoalState.Completed;
            }
        }

    }
}

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
    public class AtomGoalRoll:Goal
    {
        public AtomGoalRoll(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal, GameUnit unitPlayer) : base(brain, interestBrain, addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            UnitPlayer = unitPlayer;
        }
        protected GameUnit UnitPlayer;
        private float _rollTimer = 1f;

        public override void Avtivate()
        {
            Vector3 rollDirectionVector = UnitPlayer.gameObject.transform.position -
                                          BrainBase.GameUnit.gameObject.transform.position;

            rollDirectionVector.Normalize();
            rollDirectionVector *= -1;
            rollDirectionVector.y = 0;


            UnitCommandController unitCommandController = BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>();
            float angle = BrainBase.GameUnit.GetAngle(rollDirectionVector);//UnitPlayer.gameObject.transform.position);
            RollCommand rollCommand = new RollCommand(angle, BrainBase.GameUnit);
            rollCommand.PauseOnComplete = false;
            unitCommandController.TryToApplyCommand(rollCommand);

            GoalState=GoalState.Active;
            
        }

        public override void UpdateAction()
        {
            _rollTimer -= Time.deltaTime;

            if (_rollTimer<0)
            {
                GoalState=GoalState.Completed;
            }
        }
    }
}

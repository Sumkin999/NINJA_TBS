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
    public class AtomGoalAttack:Goal
    {
        public AtomGoalAttack(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal, GameUnit unitToAttack) : base(brain, interestBrain, addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            UnitTarget = unitToAttack;
        }
        protected GameUnit UnitTarget;

        public override void Avtivate()
        {
            InterestBrain.IsAggredByBotInterest = false;

            GoalState=GoalState.Active;
        }
        public override void UpdateAction()
        {
            
            if (UnitTarget == null)
            {
                
                GoalState=GoalState.Failed;
                return;
            }
            if (Vector3.Distance(UnitTarget.gameObject.transform.position, BrainBase.GameUnit.gameObject.transform.position) > 2.5f)
            {
                GoalState = GoalState.Failed;
                return;

            }

            BrainBase.GameUnit.Target = null;
            UnitCommandController unitCommandController = BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>();
            float angle = BrainBase.GameUnit.GetAngle(UnitTarget.gameObject.transform.position);
            AttackCommand attackCommand = new AttackCommand(angle, "Attack01", BrainBase.GameUnit);

            attackCommand.PauseOnComplete = false;
            unitCommandController.TryToApplyCommand(attackCommand);
            

            
            GoalState = GoalState.Completed;
            
        }
    }
}

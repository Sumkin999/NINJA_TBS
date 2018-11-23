using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.AtomGoals;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.CompositeGoals
{
    class CompositeGoalAttackPlayer: GoalCompostite
    {
        
        public CompositeGoalAttackPlayer(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal,GameUnit targetUnit): base(brain, interestBrain, addGoal)
        {
            BrainBase = brain;
            TargetUnit = targetUnit;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;
        }

        public GameUnit TargetUnit { get; private set; }

        public override void Avtivate()
        {
            
            
            GoalsList.Add(new AtomGoalMove(BrainBase,InterestBrain,AddGoalClass,TargetUnit));
            GoalsList.Add(new AtomGoalAttack(BrainBase, InterestBrain, AddGoalClass, TargetUnit));


            Debug.Log("Attack!!!");
            GoalState = GoalState.Active;
        }

        public override void CompletedAction()
        {
            Debug.Log("AttackGoal Complteted!!!");
        }
    }
}

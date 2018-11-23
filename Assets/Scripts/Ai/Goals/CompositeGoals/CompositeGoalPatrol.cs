using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.AtomGoals;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.CompositeGoals
{
    class CompositeGoalPatrol:GoalCompostite
    {
        public CompositeGoalPatrol(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal) : base(brain,interestBrain,addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;
        }

        public override void Avtivate()
        {

            GoalsList.Add(new AtomGoalMove(BrainBase,InterestBrain,AddGoalClass,Vector3.zero));
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, Vector3.zero));
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, Vector3.zero));

            GoalState = GoalState.Active;
        }
    }
}

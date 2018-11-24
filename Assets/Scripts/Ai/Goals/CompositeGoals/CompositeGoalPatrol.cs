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
            Vector3 v= new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f))
                + BrainBase.GameUnit.gameObject.transform.position;
            GoalsList.Add(new AtomGoalMove(BrainBase,InterestBrain,AddGoalClass,v));

            v = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f))
                + BrainBase.GameUnit.gameObject.transform.position;
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, v));

            v = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f))
                + BrainBase.GameUnit.gameObject.transform.position;
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, v));

            GoalState = GoalState.Active;
        }
    }
}

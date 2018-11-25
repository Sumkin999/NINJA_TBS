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
        private float _minIdleTimer;
        private float _maxIdleTimer;
        private float _maxPatrolRadius;

        public CompositeGoalPatrol(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal
            ,float minIdleTimer,float maxIdleTimer,float maxPatrolRadius) : base(brain,interestBrain,addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            _minIdleTimer = minIdleTimer;
            _maxIdleTimer = maxIdleTimer;
            _maxPatrolRadius = maxPatrolRadius;
        }

        public override void Avtivate()
        {
            Vector3 v= new Vector3(UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius), 0, UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius))
                + BrainBase.StartPosition;
            GoalsList.Add(new AtomGoalMove(BrainBase,InterestBrain,AddGoalClass,v));
            GoalsList.Add(new AtomGoalIdle(BrainBase,InterestBrain,AddGoalClass,UnityEngine.Random.Range(_minIdleTimer,_maxIdleTimer)));

            v = new Vector3(UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius), 0, UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius))
                + BrainBase.StartPosition;
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, v));
            GoalsList.Add(new AtomGoalIdle(BrainBase, InterestBrain, AddGoalClass, UnityEngine.Random.Range(_minIdleTimer, _maxIdleTimer)));

            v = new Vector3(UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius), 0, UnityEngine.Random.Range(-_maxPatrolRadius, _maxPatrolRadius))
                + BrainBase.StartPosition;
            GoalsList.Add(new AtomGoalMove(BrainBase, InterestBrain, AddGoalClass, v));
            GoalsList.Add(new AtomGoalIdle(BrainBase, InterestBrain, AddGoalClass, UnityEngine.Random.Range(_minIdleTimer, _maxIdleTimer)));

            GoalState = GoalState.Active;
        }
    }
}

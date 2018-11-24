using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Goals.AtomGoals;
using Assets.Scripts.Ai.Goals.CompositeGoals;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Ai.Brain
{
    public class BrainBase:MonoBehaviour
    {
        
        public GameUnit GameUnit;

        protected InterestBrain InterestBrain;
        protected AddGoalClass AddGoalClass;
        

        public void AddInterest(InterestObject interestObjectAdd)
        {
            bool contains = false;
            foreach (var interest in InterestBrain.InterestPoints)
            {
                if (interestObjectAdd.IsEqual(interest))
                {
                    contains = true;
                    break;
                }
            }
            if (!contains)
            {

                InterestBrain.InterestPoints.Add(interestObjectAdd);
            }
        }

        public void RemoveInterest(InterestObject interestObjectRemove)
        {
            foreach (var interest in InterestBrain.InterestPoints)
            {
                if (interestObjectRemove.IsEqual(interest))
                {
                    interest.IsComplteted = true;
                    break;
                }
            }
        }


        public CompositeGoalThink CompositeGoalThink { get; private set; }

        public ViewCone ViewCone;


        void Start()
        {
            GameUnit = GetComponent<GameUnit>();
            InterestBrain=new InterestBrain(this);
            AddGoalClass=new AddGoalClass(this,InterestBrain);

            CompositeGoalThink=new CompositeGoalThink(this,InterestBrain,AddGoalClass);
            CompositeGoalThink.Avtivate();

            ViewCone.SetAddGoalClass(this,AddGoalClass);
        }


        
        void Update()
        {
            CompositeGoalThink.UpdateAction();

            InterestBrain.UpdateInterestObjects();

            if (CompositeGoalThink.GoalState==GoalState.Completed
                || CompositeGoalThink.GoalState==GoalState.Failed)
            {

                CompositeGoalThink.Avtivate();
            }
        }

    }
}

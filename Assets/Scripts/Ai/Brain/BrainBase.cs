using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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


        protected CompositeGoalThink CompositeGoalThink;


        void Start()
        {
            GameUnit = GetComponent<GameUnit>();
            InterestBrain=new InterestBrain(this);

            CompositeGoalThink=new CompositeGoalThink(this);
            CompositeGoalThink.Avtivate();
        }

        void Update()
        {
            CompositeGoalThink.UpdateAction();

            if (CompositeGoalThink.GoalState==GoalState.Completed)
            {
                CompositeGoalThink.Avtivate();
            }
        }

    }
}

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

        [Header("Patrol variables")]
        [Space(5)]
        public float MinIdleTimer;
        public float MaxIdleTimer;
        public float MaxPatrolRadius;
        [Space(10)]

        [Header("Roll variables")]
        [Space(5)]
        public float TimeMinBetweenRoll;
        public int RollChance;
        [Space(10)]

        [Header("Attack variables")]
        [Space(5)]
        public float TimeMinBetweenHits;
        public float TimeMaxBetweenHits;
        [Space(10)]

        


        public List<BrainBase> BotsAggredWithThis=new List<BrainBase>();
        [Space(10)]
        public Vector3 StartPosition;

        public bool IsAgred
        {
            get
            {
                if (InterestBrain.CurrentInterestObject!=null)
                {
                    return true;
                }
                return false;
            }
        }

        
        public bool IsAggredByBot
        {
            get { return InterestBrain.IsAggredByBotInterest; }
        }

        public void SetThisAggro(InterestSpawner interestSpawner)
        {
            InterestBrain.IsAggredByBotInterest = true;



            interestSpawner.SpawnPlayerInterest(this);

            
        }

        public void AggroOthers(InterestSpawner interestSpawner)
        {
            foreach (var bot in BotsAggredWithThis)
            {
                if (!bot.IsAgred)
                {
                    bot.SetThisAggro( interestSpawner);
                }
            }
        }

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

            StartPosition = this.gameObject.transform.position;
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

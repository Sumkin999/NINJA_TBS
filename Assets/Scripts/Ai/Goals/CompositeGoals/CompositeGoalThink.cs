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
    public class CompositeGoalThink:GoalCompostite
    {
        public CompositeGoalThink(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal) : base(brain,interestBrain,addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;
        }

        public override void Avtivate()
        {

            GoalsList.Add(new CompositeGoalPatrol(BrainBase,InterestBrain,AddGoalClass,
                BrainBase.MinIdleTimer,BrainBase.MaxIdleTimer,BrainBase.MaxPatrolRadius));
            

            GoalState = GoalState.Active;
        }

        private float _nextHitTimer;
        public override void UpdateAction()
        {
            ProcessAllSubGoals();

            if (InterestBrain.CurrentInterestObject!=null)
            {

                if (InterestBrain.CurrentInterestObject is PlayerInterestObject)
                {
                    if (GoalsList.Count<1)
                    {
                        return;
                    }

                    if (!Game.GameTime.IsOnPause)
                    {
                        _nextHitTimer -= Time.deltaTime;
                    }

                    PlayerInterestObject playerInterestObject = InterestBrain.CurrentInterestObject as PlayerInterestObject;
                    
                    AddGoalClass.DecreaseRollChanceTimer(BrainBase.RollChance,BrainBase.TimeMinBetweenRoll);

                    if (playerInterestObject.Unit.gameObject.GetComponent<UnitCommandController>().State == CommandControllerState.AttackComand
                        && 
                        CheckAnglePlayerFront(playerInterestObject.Unit)>-0.25f 
                        && Vector3.Distance(BrainBase.GameUnit.gameObject.transform.position,playerInterestObject.Unit.gameObject.transform.position)<4f)
                    {
                        AddGoalClass.TryAddRollAtomGoal(playerInterestObject.Unit);
                        
                    }
                    else
                    {
                        if (!(GoalsList[0] is CompositeGoalAttackPlayer))
                        {                  
                            CommandControllerState cstate =
                                BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>().State;

                            if (_nextHitTimer<0)
                            {
                                if (cstate != CommandControllerState.AttackComand)
                                {
                                    GoalsList.Insert(0, new CompositeGoalAttackPlayer(BrainBase, InterestBrain, AddGoalClass, playerInterestObject.Unit));
                                }

                                _nextHitTimer = UnityEngine.Random.Range(BrainBase.TimeMinBetweenHits,
                                    BrainBase.TimeMaxBetweenHits);
                            }
                            
                        }
                    }

                    
                    
                }
                
            }
            
        }

        public float CheckAnglePlayerFront(GameUnit playerUnit)
        {
            Vector3 playerToThis = BrainBase.GameUnit.gameObject.transform.position -
                                   playerUnit.gameObject.transform.position;

            playerToThis.Normalize();

            return Vector3.Dot(playerToThis, playerUnit.gameObject.transform.forward);
        }


        
        public float CheckAnglePlayerLeftRight(GameUnit playerUnit)
        {
            var relativePoint = playerUnit.gameObject.transform.InverseTransformPoint(BrainBase.GameUnit.gameObject.transform.position);
            /*if (relativePoint.x < 0.0)
            {
                Debug.Log("Object is to the left");
            }
            else
            {
                Debug.Log("Object is to the right");
            }*/
            return relativePoint.x;


        }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
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

            GoalsList.Add(new CompositeGoalPatrol(BrainBase,InterestBrain,AddGoalClass));
            

            GoalState = GoalState.Active;
        }

        public override void UpdateAction()
        {
            ProcessAllSubGoals();

            if (InterestBrain.CurrentInterestObject!=null)
            {

                if (InterestBrain.CurrentInterestObject is PlayerInterestObject)
                {

                    if ((GoalsList.Count>0) && (!(GoalsList[0] is CompositeGoalAttackPlayer)) 
                        && BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>().State!=CommandControllerState.AttackComand)
                    {

                        PlayerInterestObject playerInterestObject = InterestBrain.CurrentInterestObject as PlayerInterestObject;
                        GoalsList.Insert(0, new CompositeGoalAttackPlayer(BrainBase, InterestBrain, AddGoalClass, playerInterestObject.Unit));


                        
                    }
                    
                }
                
            }
            
        }
    }
}

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
                    if (GoalsList.Count<1)
                    {
                        return;
                    }
                    if (!(GoalsList[0] is CompositeGoalAttackPlayer) )
                    {
                        
                        PlayerInterestObject playerInterestObject = InterestBrain.CurrentInterestObject as PlayerInterestObject;
                        CommandControllerState cstate =
                            BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>().State;


                        if ( cstate!= CommandControllerState.AttackComand)
                        {
                            GoalsList.Insert(0, new CompositeGoalAttackPlayer(BrainBase, InterestBrain, AddGoalClass, playerInterestObject.Unit));

                            
                            if (playerInterestObject.Unit.gameObject.GetComponent<UnitCommandController>().State == CommandControllerState.AttackComand)
                            {
                                BrainBase.CompositeGoalThink.GoalsList.Insert(0, new AtomGoalRoll(BrainBase, InterestBrain, AddGoalClass, playerInterestObject.Unit));
                            }

                            
                        }
                        else
                        {
                            AddGoalClass.TryAddRollAtomGoal(playerInterestObject.Unit);
                        }


                       
                    }
                    
                }
                
            }
            
        }
    }
}

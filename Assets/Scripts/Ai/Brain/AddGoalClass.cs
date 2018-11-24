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
    public class AddGoalClass
    {
        private BrainBase _brain;
        private InterestBrain _interestBrain;

        public AddGoalClass(BrainBase brain, InterestBrain interestBrain)
        {
            _brain = brain;
            _interestBrain = interestBrain;
        }

        public void AddMoveAtomGoal(GameUnit gameUnit)
        {
            if (_brain.CompositeGoalThink.GoalsList.Count > 0)
            {
                GoalCompostite goalCompostite = _brain.CompositeGoalThink.GoalsList[0] as GoalCompostite;

                if (goalCompostite != null)
                {
                    goalCompostite.GoalsList.Add(new AtomGoalMove(_brain, _interestBrain, this, gameUnit));
                }
            }

        }
        public void AddMoveAtomGoal(Vector3 targetPosition)
        {
            _brain.CompositeGoalThink.GoalsList.Insert(0, new AtomGoalMove(_brain, _interestBrain, this, targetPosition));
            /*if (_brain.CompositeGoalThink.GoalsList.Count > 0)
            {
                GoalCompostite goalCompostite = _brain.CompositeGoalThink.GoalsList[0] as GoalCompostite;

                if (goalCompostite != null)
                {
                    goalCompostite.GoalsList.Insert(0,new AtomGoalMove(_brain, _interestBrain, this, targetPosition));
                }
            }*/

        }

        
        private int _rollCheckChance=90;
        private float _betweenRollTimer = 3f;
        private bool _toRoll;
        
        public void TryAddRollAtomGoal(GameUnit playerUnit)
        {

            _betweenRollTimer -= Time.deltaTime;
            if (playerUnit)
            {
                int rollChance = UnityEngine.Random.Range(0, 100);
                if (rollChance<_rollCheckChance)
                {
                    _toRoll = true;
                    _betweenRollTimer = 3f;
                }
            }
            
                
                
                if (_toRoll)
                {
                    if (playerUnit.gameObject.GetComponent<UnitCommandController>().State == CommandControllerState.AttackComand
                    && _brain.GameUnit.gameObject.GetComponent<UnitCommandController>().State!=CommandControllerState.AttackComand)
                    {
                        _brain.CompositeGoalThink.GoalsList.Insert(0, new AtomGoalRoll(_brain, _interestBrain, this, playerUnit));
                        _toRoll = false;
                    }
                    
                }
                
                
            
            
           
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Goals.AtomGoals;
using Assets.Scripts.Ai.Goals.CompositeGoals;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using Assets.Scripts.GameMechanic;

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
    }
}

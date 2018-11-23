using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Interest;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.GoalsBase
{
    public class GoalCompostite:Goal
    {
        public GoalCompostite(BrainBase brain,InterestBrain interestBrain, AddGoalClass addGoal) : base(brain,interestBrain,addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;
        }
        public List<Goal> GoalsList = new List<Goal>();

        public override void UpdateAction()
        {
            ProcessAllSubGoals();
        }
        public virtual void ProcessAllSubGoals()
        {

            foreach (var goal in GoalsList)
            {
                if (goal.GoalState == GoalState.Completed)
                {

                    goal.CompletedAction();
                }
                if (goal.GoalState == GoalState.Failed)
                {
                    goal.FailedAction();
                }

            }
            for (int i = GoalsList.Count - 1; i >= 0; i--)
            {
                if (GoalsList[i].GoalState == GoalState.Completed
                    || GoalsList[i].GoalState == GoalState.Failed)
                {
                    GoalsList.RemoveAt(i);
                }
            }

            if (GoalsList.Count < 1)
            {
                GoalState = GoalState.Completed;
                return;
            }

            if (GoalsList.First().GoalState == GoalState.Inactive)
            {
                GoalsList.First().GoalState = GoalState.Active;
                GoalsList.First().Avtivate();
            }
            if (GoalsList.First().GoalState == GoalState.Active)
            {
                GoalsList.First().UpdateAction();
            }
            
        }

        public virtual void RemoveAllSubgoals()
        {
            GoalsList.Clear();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Interest;

namespace Assets.Scripts.Ai.Goals.GoalsBase
{
    public enum GoalState
    {
        Inactive,
        Active,
        Failed,
        Completed
    }
    public class Goal
    {
        public Goal(BrainBase brainBase,InterestBrain interestBrain,AddGoalClass addGoal)
        {
            BrainBase = brainBase;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;
        }
        public GoalState GoalState;
        protected BrainBase BrainBase;
        protected InterestBrain InterestBrain;
        protected AddGoalClass AddGoalClass;

        public virtual void Avtivate()
        {
            
            GoalState=GoalState.Active;
        }

        public virtual void UpdateAction()
        {
            
        }

        public virtual void CompletedAction()
        {
            
        }

        public virtual void FailedAction()
        {
            
        }
    }
}

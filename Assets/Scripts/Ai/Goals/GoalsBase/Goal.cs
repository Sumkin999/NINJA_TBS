using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;

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
        public Goal(BrainBase brainBase)
        {
            BrainBase = brainBase;
        }
        public GoalState GoalState;
        public BrainBase BrainBase;

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

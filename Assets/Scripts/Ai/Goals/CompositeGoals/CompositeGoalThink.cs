using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.GoalsBase;

namespace Assets.Scripts.Ai.Goals.CompositeGoals
{
    public class CompositeGoalThink:GoalCompostite
    {
        public CompositeGoalThink(BrainBase brain): base(brain)
        {
            BrainBase = brain;
        }

        public override void Avtivate()
        {

            GoalsList.Add(new CompositeGoalPatrol(BrainBase));
            

            GoalState = GoalState.Active;
        }
    }
}

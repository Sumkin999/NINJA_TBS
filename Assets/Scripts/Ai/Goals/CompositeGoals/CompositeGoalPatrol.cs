using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.AtomGoals;
using Assets.Scripts.Ai.Goals.GoalsBase;

namespace Assets.Scripts.Ai.Goals.CompositeGoals
{
    class CompositeGoalPatrol:GoalCompostite
    {
        public CompositeGoalPatrol(BrainBase brain): base(brain)
        {
            BrainBase = brain;
        }

        public override void Avtivate()
        {

            GoalsList.Add(new AtomGoalMove(BrainBase));
            GoalsList.Add(new AtomGoalMove(BrainBase));
            GoalsList.Add(new AtomGoalMove(BrainBase));

            GoalState = GoalState.Active;
        }
    }
}

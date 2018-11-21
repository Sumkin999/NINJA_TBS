using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.AtomGoals
{
    public class AtomGoalMove:Goal
    {
        public AtomGoalMove(BrainBase brain) : base(brain)
        {
            BrainBase = brain;
        }
        public Vector3 Destination;


        public override void Avtivate()
        {
            
            Destination= new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f))
                +BrainBase.GameUnit.gameObject.transform.position;

            UnitCommandController unitCommandController = BrainBase.GameUnit.GetComponent<UnitCommandController>();
            unitCommandController.TryToApplyCommand(new MoveCommand(Destination, BrainBase.GameUnit));
            

            GoalState = GoalState.Active;
        }

        public override void UpdateAction()
        {
            //BrainBase.GameUnit.MoveTo(Destination);


            if (Vector3.Distance(Destination, BrainBase.GameUnit.gameObject.transform.position)<0.2f)
            {
                GoalState=GoalState.Completed;
            }
        }
    }
}

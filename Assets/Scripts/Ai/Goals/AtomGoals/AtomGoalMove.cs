using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.Ai.Goals.GoalsBase;
using Assets.Scripts.Ai.Interest;
using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Ai.Goals.AtomGoals
{
    public class AtomGoalMove:Goal
    {
        public AtomGoalMove(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal,Vector3 vectorDestination) : base(brain,interestBrain,addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            Destination = vectorDestination;
        }
        public AtomGoalMove(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal, GameUnit unitDestination) : base(brain, interestBrain, addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            UnitTarget = unitDestination;
        }

        public Vector3 Destination { get; private set; }
        protected GameUnit UnitTarget;

        private MoveCommand _moveCommand;

        private float _stuckTimer;
        private Vector3 _lastPositionVector3;
        
        public override void Avtivate()
        {
            if (UnitTarget==null)
            {
                
                //Destination = new Vector3(UnityEngine.Random.Range(-10.0f, 10.0f), 0, UnityEngine.Random.Range(-10.0f, 10.0f))
                //+ BrainBase.GameUnit.gameObject.transform.position;
            }
            else
            {
                Destination = UnitTarget.gameObject.transform.position;
            }
            
            

            UnitCommandController unitCommandController = BrainBase.GameUnit.GetComponent<UnitCommandController>();
            _moveCommand = new MoveCommand(Destination, BrainBase.GameUnit);
            _moveCommand.PauseOnComplete = false;
            unitCommandController.TryToApplyCommand(_moveCommand);


            _lastPositionVector3 = BrainBase.GameUnit.gameObject.transform.position;

            GoalState = GoalState.Active;
        }

        public override void UpdateAction()
        {
            //BrainBase.GameUnit.MoveTo(Destination);
            if (UnitTarget!=null)
            {
                _moveCommand.Destination = UnitTarget.gameObject.transform.position;
                Destination = UnitTarget.gameObject.transform.position;
                /*if (Vector3.Distance(Destination,
                    UnitTarget.gameObject.transform.position)>0.25f)
                {
                    Destination = UnitTarget.gameObject.transform.position;

                    UnitCommandController unitCommandController = BrainBase.GameUnit.GetComponent<UnitCommandController>();
                    MoveCommand moveCommand = new MoveCommand(Destination, BrainBase.GameUnit);
                    moveCommand.PauseOnComplete = false;
                    unitCommandController.TryToApplyCommand(moveCommand);
                }*/

            }

            _stuckTimer += Time.deltaTime;
            if (_stuckTimer>0.5f)
            {
                if (Vector3.Distance(BrainBase.GameUnit.gameObject.transform.position,_lastPositionVector3)<0.1f)
                {
                    UnitCommandController unitCommandController = BrainBase.GameUnit.GetComponent<UnitCommandController>();
                    unitCommandController.TryToApplyCommand(_moveCommand);
                }
                _lastPositionVector3 = BrainBase.GameUnit.gameObject.transform.position;
                _stuckTimer = 0f;
            }


            if (Vector3.Distance(Destination, BrainBase.GameUnit.gameObject.transform.position)<1.75f)
            {
                GoalState=GoalState.Completed;
            }
        }
    }
}

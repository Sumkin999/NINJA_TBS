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
    public class AtomGoalRoll:Goal
    {
        public AtomGoalRoll(BrainBase brain, InterestBrain interestBrain, AddGoalClass addGoal, GameUnit unitPlayer) : base(brain, interestBrain, addGoal)
        {
            BrainBase = brain;
            InterestBrain = interestBrain;
            AddGoalClass = addGoal;

            UnitPlayer = unitPlayer;
        }
        protected GameUnit UnitPlayer;
        private UnitCommandController _unitCommandController;
        private float _rollTimer = 1f;

        private Vector3 _rollDirection;

        public override void Avtivate()
        {
            BrainBase.GameUnit.Target = UnitPlayer;
            if (BrainBase.CompositeGoalThink.CheckAnglePlayerLeftRight(UnitPlayer)>-0.25f)
            {

                Vector3 rl = BrainBase.gameObject.transform.position - BrainBase.gameObject.transform.right;
                Vector3 rv = BrainBase.gameObject.transform.position - UnitPlayer.gameObject.transform.position;
                _rollDirection = Vector3.Lerp(rl, rv,
                    Vector3.Distance(BrainBase.gameObject.transform.position, UnitPlayer.gameObject.transform.position)*0.3f);

            }
            else
            {
                _rollDirection = BrainBase.gameObject.transform.position - UnitPlayer.gameObject.transform.position;

            }
            _rollDirection.y = 0;



            _unitCommandController = BrainBase.GameUnit.gameObject.GetComponent<UnitCommandController>();
            float angle = BrainBase.GameUnit.GetAngle(_rollDirection);//UnitPlayer.gameObject.transform.position);
            RollCommand rollCommand = new RollCommand(angle, BrainBase.GameUnit);
            rollCommand.PauseOnComplete = false;
            _unitCommandController.TryToApplyCommand(rollCommand);

            GoalState=GoalState.Active;
            
        }

        public override void UpdateAction()
        {
            _rollTimer -= Time.deltaTime;

            if (_unitCommandController.State==CommandControllerState.Hitted)
            {
                _rollTimer = 0;
            }

            if (_rollTimer<0)
            {
                GoalState=GoalState.Completed;
            }
        }
    }
}

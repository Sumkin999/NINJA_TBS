using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class ViewCone:MonoBehaviour
    {
        //public GameUnit Unit;
        private BrainBase _brain;
        private AddGoalClass _addGoalClass;

        public void SetAddGoalClass(BrainBase brain,AddGoalClass addGoalClass)
        {
            _brain = brain;
            _addGoalClass = addGoalClass;
        }
        void Start()
        {
            
            //_brain = Unit.gameObject.GetComponent<BrainBase>();
        }

        void OnTriggerStay(Collider other)
        {
            InterestSpawner interestSpawner = other.gameObject.GetComponent<InterestSpawner>();

            if (interestSpawner==null)
            {
                return;
            }

            interestSpawner.SpawnPlayerInterest(_brain);
        }

        void OnTriggerExit(Collider other)
        {
            InterestSpawner interestSpawner = other.gameObject.GetComponent<InterestSpawner>();

            if (interestSpawner == null)
            {
                return;
            }

            interestSpawner.RemovePlayerInterest(_brain);

            if (_addGoalClass==null)
            {
                return;
            }
            _addGoalClass.AddMoveAtomGoal(other.gameObject.GetComponent<GameUnit>());
        }

    }
}

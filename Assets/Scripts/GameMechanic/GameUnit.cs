using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameMechanic
{
    public class GameUnit:MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public float Speed = 3.5f;
        public float RotationSpeed = 180f;
        public float Direction;
        public UnitView UnitView;
        public GameUnit Target;

        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public void MoveTo(Vector3 destination)
        {
            if (Game.GameTime.IsOnPause)
            {
                navMeshAgent.speed = 0f;
            }
            else
            {
                navMeshAgent.speed = Speed;
                UnitView.Velocity = navMeshAgent.velocity;
                UpdateMoveDirection();
            }
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void StopMove()
        {
            navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            UnitView.Velocity = Vector3.zero;
        }

        public void UpdateMoveDirection()
        {
            UnitCommandController unitCommandController = GetComponent<UnitCommandController>();
            if (unitCommandController.CurrentCommand is MoveCommand)
            {
                if (Target != null)
                {
                    Direction = GetAngle(Target.transform.position);
                    return;
                }

                Direction = GetAngle(navMeshAgent.destination);
            }
        }

        public float GetAngle(Vector3 target)
        {
            Vector3 targetVector = (target - transform.position+transform.forward*0.3f).normalized;
            float angle = -Vector2.SignedAngle(Vector2.up, new Vector2(targetVector.x, targetVector.z));
            return angle;
        }
    }
}
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameMechanic
{
    public class GameUnit:MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;

        public float Speed = 3.5f;
        public float Direction;
        public UnitView UnitView;

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
                UnitView.Velocity = navMeshAgent.desiredVelocity;
            }
            navMeshAgent.destination = destination;
            navMeshAgent.Resume();
        }
    }
}
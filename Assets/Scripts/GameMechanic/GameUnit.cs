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
        public WeaponTrigger WeaponTrigger;

        //Govnokod
        public UnitSound UnitSound;

        public float Health = 100;
        public float MaxHealth;

        public bool IsMoving { get; private set; }

        public Vector3 GetDestination { get { return navMeshAgent.destination; } }
        public float GetNavmeshVelocity { get { return navMeshAgent.velocity.sqrMagnitude; } }
        //

        void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            MaxHealth = Health;
            if (CompareTag("Enemy"))
            {
                Game.Enemies.Add(this);
            }
        }

        public void MoveTo(Vector3 destination, float speed)
        {
            if (Game.GameTime.IsOnPause)
            {
                navMeshAgent.speed = 0f;

                //Govnokod
                IsMoving = false;
                //
            }
            else
            {
                if (speed<0)
                {
                    navMeshAgent.speed = Speed;
                }
                else
                {
                    navMeshAgent.speed = speed;
                }
                UnitView.Velocity = navMeshAgent.velocity;
                UpdateMoveDirection();
                
                //Govnokod
                if (navMeshAgent.velocity.sqrMagnitude>0)
                {
                    IsMoving = true;
                }
                else
                {
                    IsMoving = false;
                }
                
                //
            }
            navMeshAgent.destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void StopMove()
        {
            navMeshAgent.destination = transform.position;
            navMeshAgent.isStopped = true;
            UnitView.Velocity = Vector3.zero;
            UpdateMoveDirection();

            //Govnokod
            IsMoving = false;
            //
        }

        public void UpdateMoveDirection()
        {
            UnitCommandController unitCommandController = GetComponent<UnitCommandController>();
            if ((unitCommandController.CurrentCommand is MoveCommand) || (unitCommandController.CurrentCommand is IdleCommand) || (unitCommandController.CurrentCommand is RollCommand))
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

        public void DealDamage(float damage)
        {
            Health -= damage;
            if (Health<=0)
            {
                Health = 0f;
                Death();
            }
        }

        private void Death()
        {
            UnitCommandController unitCommandController = GetComponent<UnitCommandController>();
            unitCommandController.TryToApplyCommand(new DeathCommand(this));
            GetComponent<Collider>().enabled = false;
            WeaponTrigger.GetComponent<Collider>().enabled = false;
            navMeshAgent.enabled = false;
            if (Game.PlayerUnit.Target == this)
            {
                Game.PlayerUnit.Target = null;
            }
        }
    }
}
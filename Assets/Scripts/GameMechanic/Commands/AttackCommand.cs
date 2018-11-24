using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class AttackCommand:BaseCommand
    {
        public float Direction;
        public string AnimatorTrigger;
        private bool animationStarted;
        public float MoveDistance = 2;
        public float MoveSpeed = 3.5f;
        public float TimeToComplete = 0.8f;
        private Vector3 moveTarget;
        private float timer = 0f;
        public float Damage = 10;
        public float TimeToActivateTrigger = 0.2f;
        public float TimeToDeactivateTrigger = 0.4f;


        public AttackCommand(float direction, string animatorTrigger, GameUnit target)
        {
            PauseOnComplete = true;
            Direction = direction;
            AnimatorTrigger = animatorTrigger;
            Target = target;
            timer = 0f;

            moveTarget =
                new Vector3(Mathf.Sin(Mathf.Deg2Rad * direction), 0f, Mathf.Cos(Mathf.Deg2Rad * direction)).normalized *
                MoveDistance + target.transform.position;
        }

        public override void UpdateCommand()
        {
            Target.Direction = Direction;

            if ( Mathf.Abs(Direction - Target.UnitView.CurrentDirection) > 60)
                return;

            if (!animationStarted)
            {
                animationStarted = true;
                Target.UnitView.Animator.SetTrigger(AnimatorTrigger);

                //GOVNOKOD
                if (Target.UnitSound!=null)
                {
                    Target.UnitSound.SwordWindSoundPlay();
                }
                
                //
            }
            else
            {
                Target.MoveTo(moveTarget,MoveSpeed);
            }

            StopMoveNearEnemy();

            //Таймеры не считаем на паузе
            if (Game.GameTime.IsOnPause)
                return;

            if (animationStarted)
                timer += Time.deltaTime;

            Collider collider = Target.WeaponTrigger.GetComponent<Collider>();

            if ((timer > TimeToActivateTrigger) && (timer < TimeToDeactivateTrigger))
            {
                collider.enabled = true;
            }
            else
            {
                collider.enabled = false;
            }

            if (timer > TimeToComplete)
            {
                CompleteCommand();
            }

        }

        private void StopMoveNearEnemy()
        {
            Vector3 rayFrom = Target.transform.position;
            Ray ray = new Ray(rayFrom, Target.UnitView.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 0.7f);

            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Target.StopMove();
                }
            }
        }

        public override bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            if (newCommand is MoveCommand)
            {
                return false;
            }

            return true;
        }

        public override void OnWeaponnTriggeredEnemy(GameUnit enemy)
        {
            enemy.DealDamage(Damage);
            Debug.Log(enemy.Health);
        }
    }
}
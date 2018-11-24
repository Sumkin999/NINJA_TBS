using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class RollCommand:BaseCommand
    {
        public float Direction;
        public float MoveDistance = 3;
        public float MoveSpeed = 5f;
        private Vector3 moveTarget;
        public float TimeToComplete = 0.8f;
        private float timer = 0f;

        public RollCommand(float direction, GameUnit target)
        {
            PauseOnComplete = true;
            Direction = direction;
            Target = target;

            moveTarget =
                new Vector3(Mathf.Sin(Mathf.Deg2Rad * direction), 0f, Mathf.Cos(Mathf.Deg2Rad * direction)).normalized *
                MoveDistance + target.transform.position;
        }

        public override void UpdateCommand()
        {
            Target.UnitView.Animator.SetBool("Roll",true);

            Target.MoveTo(moveTarget, MoveSpeed);

            StopMoveNearEnemy();

            //Таймеры не считаем на паузе
            if (Game.GameTime.IsOnPause)
                return;

            timer += Time.deltaTime;

            if (timer > TimeToComplete)
            {
                CompleteCommand();
            }
        }

        private void StopMoveNearEnemy()
        {
            Vector3 rayFrom = Target.transform.position;
            Vector3 direction = (moveTarget - Target.transform.position).normalized;
            Ray ray = new Ray(rayFrom, direction);
            RaycastHit[] hits = Physics.RaycastAll(ray, 0.7f);

            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Target.StopMove();
                    return;
                }
            }

        }

        public override void StopCommand()
        {
            Target.UnitView.Animator.SetBool("Roll", false);
            Target.StopMove();
        }

        public override bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            if (newCommand is MoveCommand)
            {
                return false;
            }
            if (newCommand is AttackCommand)
            {
                return false;
            }
            if (newCommand is RollCommand)
            {
                return false;
            }

            return true;
        }
    }
}
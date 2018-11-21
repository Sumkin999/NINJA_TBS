using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class RollCommand:BaseCommand
    {
        public float Direction;
        public float MoveDistance = 2;
        public float MoveSpeed = 3.5f;
        private Vector3 moveTarget;

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
            //Target.UnitView.Animator.SetTrigger(AnimatorTrigger);

            Target.MoveTo(moveTarget);
        }
    }
}
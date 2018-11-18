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
        private Vector3 moveTarget;


        public AttackCommand(float direction, string animatorTrigger, GameUnit target)
        {
            Direction = direction;
            AnimatorTrigger = animatorTrigger;
            Target = target;

            moveTarget =
                new Vector3(Mathf.Sin(Mathf.Deg2Rad * direction), 0f, Mathf.Cos(Mathf.Deg2Rad * direction)).normalized *
                MoveDistance + target.transform.position;
        }

        public override void UpdateCommand()
        {
            Target.Direction = Direction;

            if ( Mathf.Abs(Direction - Target.UnitView.CurrentDirection) > 5)
                return;

            if (!animationStarted)
            {
                animationStarted = true;
                Target.UnitView.Animator.SetTrigger(AnimatorTrigger);
            }
            else
            {
                Target.MoveTo(moveTarget);
            }

            Vector3 rayFrom = Target.transform.position;
            Ray ray = new Ray(rayFrom, Target.UnitView.transform.forward);
            RaycastHit[] hits = Physics.RaycastAll(ray, 0.7f);

            Debug.DrawLine(rayFrom, rayFrom+ Target.UnitView.transform.forward*2f,Color.red);

            foreach (var hit in hits)
            {
                if (hit.transform.gameObject.CompareTag("Enemy"))
                {
                    Target.StopMove();
                }
            }
        }
    }
}
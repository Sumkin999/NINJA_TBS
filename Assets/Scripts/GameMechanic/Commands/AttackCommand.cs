using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class AttackCommand:BaseCommand
    {
        public float Direction;
        public string AnimatorTrigger;
        private bool animationStarted;


        public AttackCommand(float direction, string animatorTrigger, GameUnit target)
        {
            Direction = direction;
            AnimatorTrigger = animatorTrigger;
            Target = target;
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
        }
    }
}
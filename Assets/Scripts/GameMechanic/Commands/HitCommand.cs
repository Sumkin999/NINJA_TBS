using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class HitCommand:BaseCommand
    {
        public float TimeToComplete = 0.4f;
        private float timer = 0f;
        private bool animationStarted = false;

        public HitCommand(GameUnit target)
        {
            PauseOnComplete = true;
            Target = target;
            timer = 0f;
        }

        public override void UpdateCommand()
        {
            if (!animationStarted)
            {
                Target.UnitView.Animator.SetTrigger("Hit");
                animationStarted = true;
            }

            //Таймеры не считаем на паузе
            if (Game.GameTime.IsOnPause)
                return;

            timer += Time.deltaTime;

            if (timer > TimeToComplete)
            {
                CompleteCommand();
            }

        }

        public override bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            if (newCommand is MoveCommand)
            {
                return false;
            }

            if (newCommand is RollCommand)
            {
                return false;
            }

            if (newCommand is AttackCommand)
            {
                return false;
            }

            return true;
        }
    }
}
namespace Assets.Scripts.GameMechanic.Commands
{
    public class DeathCommand:BaseCommand
    {
        private bool animationStarted = false;

        public DeathCommand(GameUnit target)
        {
            Target = target;
        }

        public override void UpdateCommand()
        {
            if (!animationStarted)
            {
                Target.UnitView.Animator.SetTrigger("Death");
                animationStarted = true;
            }
        }

        public override bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            return false;
        }
    }
}
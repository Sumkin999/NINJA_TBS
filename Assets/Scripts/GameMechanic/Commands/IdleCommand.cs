namespace Assets.Scripts.GameMechanic.Commands
{
    public class IdleCommand:BaseCommand
    {
        public IdleCommand(GameUnit target)
        {
            Target = target;
        }

        public override void UpdateCommand()
        {
            Target.StopMove();
        }
    }
}
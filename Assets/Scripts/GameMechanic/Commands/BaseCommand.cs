namespace Assets.Scripts.GameMechanic.Commands
{
    public class BaseCommand
    {
        public GameUnit Target;

        public virtual void UpdateCommand()
        {
            
        }

        public void CompleteCommand()
        {
            
        }

        public bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            ////TODO
            return true;
        }


    }
}
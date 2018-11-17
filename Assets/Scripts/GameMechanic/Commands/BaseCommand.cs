using UnityEngine;

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

        public virtual  bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            ////TODO
            return true;
        }


    }
}
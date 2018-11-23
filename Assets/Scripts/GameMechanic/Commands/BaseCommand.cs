using UnityEngine;

namespace Assets.Scripts.GameMechanic.Commands
{
    public class BaseCommand
    {
        public GameUnit Target;
        public bool PauseOnComplete;

        public virtual void UpdateCommand()
        {
            
        }

        public virtual void StopCommand() { }

        public void CompleteCommand()
        {
            UnitCommandController unitCommandController = Target.GetComponent<UnitCommandController>();
            unitCommandController.CompleteCommand(this);
        }

        public virtual  bool CanBeInterruptedByCommand(BaseCommand newCommand)
        {
            ////TODO
            return true;
        }

        public virtual void OnWeaponnTriggeredEnemy(GameUnit enemy){ }


    }
}
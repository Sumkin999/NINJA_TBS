using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public enum CommandControllerState
    {
        CommandRun,
        WaitingCommand
    };

    public class UnitCommandController:MonoBehaviour
    {
        public CommandControllerState State;

        private BaseCommand currentCommand;

        public bool TryToApplyCommand(BaseCommand newCommand)
        {
            if (currentCommand != null)
            {
                if (currentCommand.CanBeInterruptedByCommand(newCommand))
                {
                    currentCommand = newCommand;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                currentCommand = newCommand;
                return true;
            }
        }

        public void Update()
        {
            if (currentCommand!= null)
            {
                currentCommand.UpdateCommand();
            }
        }

    }
}
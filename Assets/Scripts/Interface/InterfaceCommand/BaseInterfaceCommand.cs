using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Interface.InterfaceCommand
{
    public enum CommandState { Hidden, Available, TargetSelection, Active};

    public class BaseInterfaceCommand:MonoBehaviour
    {
        public CommandState State;
        public CommandButton CommandButton;

        public virtual void OnSelectCommand() {}
        public virtual void UpdateSelection() {}

        public void OnTargetSelected()
        {
            State = CommandState.Active;
        }

        public virtual void OnTerrainClick(Vector3 destination){}

        public virtual void UpdateCommand() {}
        public virtual void StartCommand() { }

        public virtual void SelectAvailableCommands(List<BaseInterfaceCommand> commands)
        {
            foreach (var command in commands)
            {
                if (command is InterfaceCommandMove)
                {
                    command.State = CommandState.Available;
                }

                if (command is InterfaceCommandAttack01)
                {
                    command.State = CommandState.Available;
                }
            }
        }
    }
}
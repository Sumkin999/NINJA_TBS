using System.Collections.Generic;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Interface.InterfaceCommand
{
    public enum CommandState { Hidden, Available, TargetSelection, Active};

    public class BaseInterfaceCommand:MonoBehaviour
    {
        public CommandState State;
        public CommandButton CommandButton;
        public bool UnpauseOnTargetSelected;
        public float StaminaCost;
        public bool ShowSelector;
        public float SelectorDistance;

        public virtual void OnSelectCommand() {}
        public virtual void UpdateSelection() {}

        public void OnTargetSelected()
        {
            if (StaminaCost>Game.PlayerUnit.Stamina)
                return;

            Game.PlayerUnit.DecreaseStamina(StaminaCost);

            State = CommandState.Active;
            Game.InterfaceCommandController.RunCommand(this);

            if (Game.GameTime.IsOnPause && UnpauseOnTargetSelected)
            {
                Game.GameTime.UnpauseGame();
            }
        }

        public virtual void OnTerrainClick(Vector3 destination){}

        public virtual void UpdateCommand() {}

        public virtual void SelectAvailableCommands(List<BaseInterfaceCommand> commands)
        {
            foreach (var command in commands)
            {
                if (command is InterfaceCommandMove)
                {
                    SetAvailableIfHidden(command);
                    continue;
                }

                if (command is InterfaceCommandAttack01)
                {
                    SetAvailableIfHidden(command);
                    continue;
                }

                if (command is InterfaceCommandRoll)
                {
                    SetAvailableIfHidden(command);
                    continue;
                }

                command.State = CommandState.Hidden;
            }
        }

        protected void SetAvailableIfHidden(BaseInterfaceCommand command)
        {
            if (command.State == CommandState.Hidden)
            {
                command.State = CommandState.Available;
            }
        }
    }
}
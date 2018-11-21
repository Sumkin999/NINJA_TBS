using System.Collections.Generic;
using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Interface.InterfaceCommand
{
    public class InterfaceCommandRoll:BaseInterfaceCommand
    {
        public override void OnTerrainClick(Vector3 destination)
        {
            UnitCommandController unitCommandController = Game.PlayerUnit.GetComponent<UnitCommandController>();
            float angle = Game.PlayerUnit.GetAngle(destination);
            unitCommandController.TryToApplyCommand(new RollCommand(angle, Game.PlayerUnit));
            UnpauseOnTargetSelected = true;
            OnTargetSelected();
        }

        public override void SelectAvailableCommands(List<BaseInterfaceCommand> commands)
        {
            foreach (var command in commands)
            {
                command.State = CommandState.Hidden;
            }
        }
    }
}
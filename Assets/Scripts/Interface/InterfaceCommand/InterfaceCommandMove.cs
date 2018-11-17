using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Interface.InterfaceCommand
{
    public class InterfaceCommandMove:BaseInterfaceCommand
    {
        public Vector3 Destination; 

        public InterfaceCommandMove(Vector3 destination)
        {
            Destination = destination;
        }

        public override void StartCommand()
        {
            UnitCommandController unitCommandController = Game.PlayerUnit.GetComponent<UnitCommandController>();
            unitCommandController.TryToApplyCommand(new MoveCommand(Destination,Game.PlayerUnit));
        }

        public override void OnTerrainClick(Vector3 destination)
        {
            UnitCommandController unitCommandController = Game.PlayerUnit.GetComponent<UnitCommandController>();
            unitCommandController.TryToApplyCommand(new MoveCommand(destination, Game.PlayerUnit));
            OnTargetSelected();
        }
    }
}
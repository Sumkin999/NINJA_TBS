using Assets.Scripts.GameMechanic;
using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.Interface.InterfaceCommand
{
    public class InterfaceCommandAttack01:BaseInterfaceCommand
    {
        public override void OnTerrainClick(Vector3 destination)
        {
            UnitCommandController unitCommandController = Game.PlayerUnit.GetComponent<UnitCommandController>();
            float angle = Vector3.SignedAngle(Vector3.forward, Game.PlayerUnit.transform.forward, Vector3.up);
            unitCommandController.TryToApplyCommand(new AttackCommand(angle, "Attack01", Game.PlayerUnit));
            OnTargetSelected();
        }
    }
}
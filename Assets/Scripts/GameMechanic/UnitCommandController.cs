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


    }
}
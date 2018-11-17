using Assets.Scripts.GameMechanic;
using Assets.Scripts.Interface.InterfaceCommand;
using UnityEngine;

namespace Assets.Scripts.Interface
{
    public class CommandButton:MonoBehaviour
    {
        public BaseInterfaceCommand InterfaceCommand;
        public GameObject SelectingGameObject;

        public void SelectCommand()
        {
            Game.InterfaceCommandController.SelectCommand(InterfaceCommand);
        }

        public void Update()
        {
            if (InterfaceCommand.State == CommandState.TargetSelection)
            {
                SelectingGameObject.SetActive(true);
            }
            else
            {
                SelectingGameObject.SetActive(false);
            }
        }
    }
}

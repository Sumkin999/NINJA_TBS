using System.Collections.Generic;
using Assets.Scripts.GameMechanic;
using Assets.Scripts.Interface.InterfaceCommand;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Interface
{
    public class InterfaceCommandController:MonoBehaviour
    {
        private BaseInterfaceCommand currentCommand;

        public List<BaseInterfaceCommand> AllCommands;

        private InterfaceCommandMove moveCommand;

        public BaseInterfaceCommand SelectedCommand;

        void Start()
        {
            foreach (var command in AllCommands)
            {
                if (command is InterfaceCommandMove)
                {
                    moveCommand = command as InterfaceCommandMove;
                }
            }

            Game.InterfaceCommandController = this;
        }

        void Update()
        {
            if (currentCommand != null)
            {
                currentCommand.UpdateCommand();
                currentCommand.SelectAvailableCommands(AllCommands);
                UpdateCommandButtons();
            }

            if (SelectedCommand != null)
            {
                SelectedCommand.UpdateSelection();

                if (SelectedCommand.State != CommandState.TargetSelection)
                {
                    SelectedCommand = null;
                }
            }

            LeftClickHolder();
            SpaceDownHolder();
        }

        public void RunCommand(BaseInterfaceCommand newCommand)
        {
            currentCommand = newCommand;
            currentCommand.StartCommand();
        }

        public void SelectCommand(BaseInterfaceCommand command)
        {
            if (command == SelectedCommand)
                return;

            if (SelectedCommand != null)
            {
                if (SelectedCommand == currentCommand)
                {
                    SelectedCommand.State = CommandState.Active;
                }
                else
                {
                    SelectedCommand.State = CommandState.Available;
                }
            }

            SelectedCommand = command;
            SelectedCommand.State = CommandState.TargetSelection;
            SelectedCommand.OnSelectCommand();
        }

        public void LeftClickHolder()
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            

            if (Input.GetButtonDown("Fire1"))
            {
                Ray ray =  UnityEngine.Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.transform.gameObject.CompareTag("Enemy"))
                    {
                        SelectDeselectTarget(hit.transform.gameObject);
                    }
                    else
                    {
                        if (SelectedCommand == null)
                        {
                            SelectedCommand = moveCommand;
                            SelectedCommand.OnTerrainClick(hit.point);
                        }
                        else
                        {
                            SelectedCommand.OnTerrainClick(hit.point);
                        }
                    }
                }
            }
        }

        private void UpdateCommandButtons()
        {
            foreach (var command in AllCommands)
            {
                if (command.State == CommandState.Hidden)
                {
                    command.CommandButton.gameObject.SetActive(false);
                }
                else
                {
                    command.CommandButton.gameObject.SetActive(true);
                }
            }
        }

        public void SelectDeselectTarget(GameObject target)
        {
            GameUnit targetUnit = target.GetComponent<GameUnit>();
            if ((Game.PlayerUnit.Target == null) || (Game.PlayerUnit.Target != targetUnit))
            {
                Game.PlayerUnit.Target = targetUnit;
            }
            else
            {
                Game.PlayerUnit.Target = null;
            }
        }

        public void SpaceDownHolder()
        {
            if (Input.GetButtonDown("Jump"))
            {
                Game.GameTime.SwitchPause();
            }
        }
    }
}
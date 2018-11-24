using Assets.Scripts.GameMechanic.Commands;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public enum CommandControllerState
    {
        CommandRun,
        WaitingCommand,
        AttackComand,
        RollCommand
    };

    public class UnitCommandController:MonoBehaviour
    {
        public CommandControllerState State;

        public BaseCommand CurrentCommand;

        public bool TryToApplyCommand(BaseCommand newCommand)
        {
            if (CurrentCommand != null)
            {
                if (CurrentCommand.CanBeInterruptedByCommand(newCommand))
                {
                    CurrentCommand.StopCommand();
                    CurrentCommand = newCommand;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                CurrentCommand = newCommand;
                return true;
            }
        }

        public void Update()
        {
            if (CurrentCommand!= null)
            {
                CurrentCommand.UpdateCommand();

                if (CurrentCommand is AttackCommand)
                {
                    State=CommandControllerState.AttackComand;
                    return;
                    
                }
                if (CurrentCommand is MoveCommand)
                {
                    State = CommandControllerState.CommandRun;
                    return;
                }
                if (CurrentCommand is RollCommand)
                {
                    State = CommandControllerState.RollCommand;
                    return;
                }
                
                State = CommandControllerState.WaitingCommand;

                
            }
        }

        public void CompleteCommand(BaseCommand command)
        {
            if (CurrentCommand != command)
                return;

            command.StopCommand();
            CurrentCommand = new IdleCommand(GetComponent<GameUnit>());

            if (command.PauseOnComplete)
                Game.GameTime.PauseGame();
        }

    }
}
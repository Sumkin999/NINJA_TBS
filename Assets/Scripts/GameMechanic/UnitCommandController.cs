﻿using Assets.Scripts.GameMechanic.Commands;
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
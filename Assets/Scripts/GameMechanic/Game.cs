using System.Collections.Generic;
using Assets.Scripts.Interface;

namespace Assets.Scripts.GameMechanic
{
    public static class Game
    {
        public static GameUnit PlayerUnit;
        public static GameTime GameTime;
        public static InterfaceCommandController InterfaceCommandController;
        public static InterfaceMainController InterfaceMainController;
        public static List<GameUnit> Enemies = new List<GameUnit>();

    }
}
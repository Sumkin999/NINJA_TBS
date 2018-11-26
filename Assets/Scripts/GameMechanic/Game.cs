using System.Collections.Generic;
using Assets.Scripts.Interface;
using Assets.Scripts.Visuals;

namespace Assets.Scripts.GameMechanic
{
    public static class Game
    {
        public static GameUnit PlayerUnit;
        public static GameTime GameTime;
        public static InterfaceCommandController InterfaceCommandController;
        public static InterfaceMainController InterfaceMainController;
        public static List<GameUnit> Enemies = new List<GameUnit>();
        public static MainParticleController MainParticleController;
        public static bool EnemyFriendlyFire = false;
    }
}
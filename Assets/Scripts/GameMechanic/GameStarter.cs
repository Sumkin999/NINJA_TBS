using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class GameStarter:MonoBehaviour
    {
        void Start()
        {
            Game.PlayerUnit = GetComponent<GameUnit>();
            Game.GameTime = GetComponent<GameTime>();
        }
    }
}
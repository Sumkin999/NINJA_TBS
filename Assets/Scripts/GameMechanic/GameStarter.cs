using Assets.Scripts.Interface;
using UnityEngine;

namespace Assets.Scripts.GameMechanic
{
    public class GameStarter:MonoBehaviour
    {
        void Start()
        {
            Game.PlayerUnit = GetComponent<GameUnit>();
            Game.GameTime = GetComponent<GameTime>();
            Game.InterfaceMainController = GetComponent<InterfaceMainController>();

            Debug.Log("START "+this.gameObject.name);
        }
    }
}
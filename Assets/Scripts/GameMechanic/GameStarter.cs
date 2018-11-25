using Assets.Scripts.Interface;
using Assets.Scripts.Visuals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.GameMechanic
{
    public class GameStarter:MonoBehaviour
    {
        void Start()
        {
            SceneManager.LoadScene("UI",LoadSceneMode.Additive);

            Game.PlayerUnit = GetComponent<GameUnit>();
            Game.GameTime = GetComponent<GameTime>();
            Game.MainParticleController = GetComponent<MainParticleController>();



        }
    }
}
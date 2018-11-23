using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using Assets.Scripts.GameMechanic;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class InterestSpawner:MonoBehaviour
    {
        private GameUnit _gameUnit;

        void Start()
        {
            _gameUnit = GetComponent<GameUnit>();
        }
        public void SpawnPlayerInterest(BrainBase brainTo)
        {
           brainTo.AddInterest(new PlayerInterestObject(_gameUnit));     
        }
        public void RemovePlayerInterest(BrainBase brainTo)
        {
            brainTo.RemoveInterest(new PlayerInterestObject(_gameUnit));
        }

        

    }
}

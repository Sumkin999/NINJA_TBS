using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Scripts.Ai.Brain;
using UnityEngine;

namespace Assets.Scripts.Ai.Interest
{
    public class InterestSpawner:MonoBehaviour
    {
        public void SpawnPlayerInterest(BrainBase brainTo)
        {
           brainTo.AddInterest(new PlayerInterestObject());     
        }

        public void SpawnPointInterest(BrainBase brainTo)
        {
            brainTo.AddInterest(new PlayerPositionInterestObject());
        }

    }
}
